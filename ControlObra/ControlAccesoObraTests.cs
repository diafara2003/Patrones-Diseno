using ControlObra.Dominio;
using FluentAssertions;

namespace ControlObra;

public class ControlAccesoObraTests
{
    [Fact(DisplayName = "Un trabajador puede ingresar si no hay reglas restrictivas configuradas.")]
    public void UnTrabajadorPuedeIngresarSiNoHayReglasRestrictivasConfiguradas()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra();
        var trabajador = new Worker("Juan", "Perez", "12345678", TypeSpecialty.Carpintero, 60);

        // Act
        var resultado = controlAcceso.SignIn(trabajador);

        // Assert
        resultado.Should().Be(ControlAccesoObra.IngresoExitoso);
    }

    [Fact(DisplayName = "Un trabajador tipo Operador de maquina no puede ingresar por la regla de especialidad   ")]
    public void UnTrabajadorNoPuedeIngresarSiHayReglasRestrictivasConfiguradas()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra();
        var trabajador = new Worker("Juan", "Perez", "12345678", TypeSpecialty.OperarioMaquina, 0);

        // Act
        var resultado = controlAcceso.SignIn(trabajador);

        // Assert
        resultado.Should().Be(ControlAccesoObra.NoCumpleConLaReglaDeEspecialidad);
    }

    [Fact(DisplayName =
        "Si un trabajador no cumple con la regla de cedula no puede ingresar - Solo cedulas pares ingresan")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCedula()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra();
        var trabajador = new Worker("Juan", "Perez", "12345679", TypeSpecialty.Carpintero, 0);

        // Act
        var resultado = controlAcceso.SignIn(trabajador);

        // Assert
        resultado.Should().Be(ControlAccesoObra.NoCumpleConLaReglaDeCedula);
    }

    [Fact(DisplayName = "Un Empleado no puede ingresar por la regla del avance minimo del 50%")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeAvanceMinimo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra();
        var trabajador = new Worker("Juan", "Perez", "12345678", TypeSpecialty.Carpintero, 0);

        // Act
        var resultado = controlAcceso.SignIn(trabajador);

        // Assert
        resultado.Should().Be(ControlAccesoObra.NoCumpleConLaReglaDelAvanceMinimo);
    }
}