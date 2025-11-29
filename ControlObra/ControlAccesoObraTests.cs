using ControlObra.Dominio;
using ControlObra.Dominio.Rules;
using FluentAssertions;

namespace ControlObra;

public class ControlAccesoObraTests
{
    [Fact(DisplayName = "Un trabajador puede ingresar si no hay reglas restrictivas configuradas.")]
    public void UnTrabajadorPuedeIngresarSiNoHayReglasRestrictivasConfiguradas()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero, 60);


        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("Ingreso exitoso");
    }

    [Fact(DisplayName = "Un trabajador tipo Operador de maquina no puede ingresar por la regla de especialidad   ")]
    public void UnTrabajadorNoPuedeIngresarSiHayReglasRestrictivasConfiguradas()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForSpecialty(TypeSpecialty.Carpintero)], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.OperarioMaquina, 0);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de especialidad");
    }

    [Fact(DisplayName =
        "Si un trabajador no cumple con la regla de cedula no puede ingresar - Solo cedulas pares ingresan")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCedula()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForDocumentNumberEven()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345679",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero, 0);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cedula");
    }

    [Fact(DisplayName = "Un Empleado no puede ingresar por la regla del avance minimo del 50%")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeAvanceMinimo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForProgress()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero,
            0);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de progreso");
    }

    [Fact(DisplayName = "Un Empleado solo puede ingresar si cumple años ese dia")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCumpleaños()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForBirthDate()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 10, 28),
            TypeSpecialty.Carpintero, 60);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cumpleaños");
    }

    [Fact(DisplayName = "Un Empleado solo puede ingresar si cumple años ese dia y es carpintero")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCumpleañosYEsCarpintero()
    {
        // Arrange
        var controlAcceso =
            new ControlAccesoObra([new RuleForBirthDate(), new RuleForSpecialty(TypeSpecialty.OperarioMaquina)], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 10, 28),
            TypeSpecialty.Carpintero, 60);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cumpleaños, No cumple con la regla de especialidad");
    }


    [Fact(DisplayName = "Si la salida de un empleado es por almuerzo siempre es exitosa y no modifica el avance")]
    public void SalidaPorAlmuerzoEsExitosa()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero, 60);
        controlAcceso.Enter(trabajador);

        // Act
        var result = controlAcceso.Exit(trabajador.documentNumber, trabajador.progress, ExitType.Lunch);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Un empleado no puede salir si su avance es menor al 50% y no es por almuerzo")]
    public void UnEmpleadoNoPuedeSalirSiSuAvanceEsMenorAl50PorcientoYNoEsPorAlmuerzo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "Perez", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero, 20);
        controlAcceso.Enter(trabajador);

        // Act
        var result = controlAcceso.Exit(trabajador.documentNumber, trabajador.progress, ExitType.Other);

        // Assert
        result.Should().BeFalse();
    }
}