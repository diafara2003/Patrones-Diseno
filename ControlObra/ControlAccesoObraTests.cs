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
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);


        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("Ingreso exitoso");
        controlAcceso.Workers.Should().HaveCount(1);
    }

    [Fact(DisplayName = "Un trabajador tipo Operador de maquina no puede ingresar por la regla de especialidad   ")]
    public void UnTrabajadorNoPuedeIngresarSiHayReglasRestrictivasConfiguradas()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForSpecialty(TypeSpecialty.Carpintero)], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.OperarioMaquina);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de especialidad");
        controlAcceso.Workers.Should().HaveCount(0);
    }

    [Fact(DisplayName = "Solo pueden ingresar trabajadores que empiecen por J")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeNombre()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForName("A")], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.OperarioMaquina);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be($"No cumple con la regla de nombre, debe empezar por A");
        controlAcceso.Workers.Should().HaveCount(0);
    }

    [Fact(DisplayName =
        "Si un trabajador no cumple con la regla de cedula no puede ingresar - Solo cedulas pares ingresan")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCedula()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForDocumentNumberEven()], 50);
        var trabajador = new Worker("Juan", "12345679",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cedula");
        controlAcceso.Workers.Should().HaveCount(0);
    }

    [Fact(DisplayName = "Un trabajador no puede ingresar por la regla del avance minimo del 50%")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeAvanceMinimo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForProgress()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de progreso");
        controlAcceso.Workers.Should().HaveCount(0);
    }

    [Fact(DisplayName = "Un trabajador solo puede ingresar si cumple años ese dia")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCumpleaños()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new RuleForBirthDate()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 10, 28),
            TypeSpecialty.Carpintero);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cumpleaños");
        controlAcceso.Workers.Should().HaveCount(0);
    }

    [Fact(DisplayName = "Un trabajador solo puede ingresar si cumple años ese dia y es carpintero")]
    public void UnTrabajadorNoPuedeIngresarSiNoCumpleConLaReglaDeCumpleañosYEsCarpintero()
    {
        // Arrange
        var controlAcceso =
            new ControlAccesoObra([new RuleForBirthDate(), new RuleForSpecialty(TypeSpecialty.OperarioMaquina)], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 10, 28),
            TypeSpecialty.Carpintero);

        // Act
        var resultado = controlAcceso.Enter(trabajador);

        // Assert
        resultado.Should().Be("No cumple con la regla de cumpleaños, No cumple con la regla de especialidad");
        controlAcceso.Workers.Should().HaveCount(0);
    }


    [Fact(DisplayName = "Si la salida de un trabajador es por almuerzo siempre es exitosa y no modifica el avance")]
    public void SalidaPorAlmuerzoEsExitosa()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);

        // Act
        var result = controlAcceso.ExitForLunch(trabajador.DocumentNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Un trabajador no puede salir si su avance es menor al 50% y no es por almuerzo")]
    public void UntrabajadorNoPuedeSalirSiSuAvanceEsMenorAl50PorcientoYNoEsPorAlmuerzo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);

        // Act
        var result = controlAcceso.Exit(trabajador.DocumentNumber, trabajador.Progress);

        // Assert
        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Si un trabajador sale con avance mayor o igual al 50% la salida es exitosa")]
    public void UntrabajadorPuedeSalirSiSuAvanceEsMayorOIgualAl50Porciento()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);
        controlAcceso.Exit(trabajador.DocumentNumber, 51);

        // Act
        var result = controlAcceso.Exit(trabajador.DocumentNumber, 10);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Si se intenta registrar una salida de un trabajador que no existe debe lanzar exepcion")]
    public void UntrabajadorNoPuedeSalirSiNoEstaRegistrado()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);

        // Act
        Action act = () => controlAcceso.Exit(trabajador.DocumentNumber, 10);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact(DisplayName = "Si un trabajador sale multiples veces el progreso debe aumentar")]
    public void SiUntrabajadorSaleMultiplesVecesElProgresoDebeAumentar()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);
        controlAcceso.Exit(trabajador.DocumentNumber, 51);

        // Act
        controlAcceso.Exit(trabajador.DocumentNumber, 5);

        // Assert
        controlAcceso.GetWorker(trabajador.DocumentNumber).Progress.Should().Be(56);
    }

    [Fact(DisplayName = "Si busco un trabajador que no existe debe lanzar exepcion")]
    public void SiBuscoUnTrabajadorQueNoExisteDebeLanzarExepcion()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);

        // Act
        Action act = () => controlAcceso.GetWorker("12345678");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact(DisplayName =
        "Si un trabajador completa el 100% de avance y si registra una salida  que no sea de almuerzo debe lanzar exepcion")]
    public void SiUntrabajadorCompletaEl100PorcientoNoPuedeVolverARegistrarSalida()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);
        controlAcceso.Exit(trabajador.DocumentNumber, 100);

        // Act
        Action act = () => controlAcceso.Exit(trabajador.DocumentNumber, 10);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact(DisplayName =
        "Si un trabajador completa el 100% de avance y si registra una salida de almuerzo debe ser exitosa")]
    public void SiUntrabajadorCompletaEl100PorcientoPuedeVolverARegistrarSalidaDeAlmuerzo()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678",
            new DateTime(2025, 11, 28),
            TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);
        controlAcceso.Exit(trabajador.DocumentNumber, 100);

        // Act
        var result = controlAcceso.ExitForLunch(trabajador.DocumentNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact(DisplayName = "Si creo un trabajador sin documento debe lanzar exepcion")]
    public void SiCreoUnWorkerSinDocumentoDebeLanzarExepcion()
    {
        var caller = () => new Worker("Juan", "", DateTime.Now, TypeSpecialty.Carpintero);
        caller.Should().Throw<ArgumentException>();
    }

    [Fact(DisplayName = "Si creo un trabajador sin nombre debe lanzar exepcion")]
    public void SiCreoUnWorkerSinNombreDebeLanzarExepcion()
    {
        var caller = () => new Worker("", "1231231", DateTime.Now, TypeSpecialty.Carpintero);
        caller.Should().Throw<ArgumentException>();
    }

    [Fact(DisplayName = "Si un trabajador sale 4 veces de la obra debe aumentar el contador de salidas del trabajador")]
    public void SiUntrabajadorSale4VecesDeLaObraDebeAumentarElContadorDeSalidasDelTrabajador()
    {
        // Arrange
        var controlAcceso = new ControlAccesoObra([new EmptyRule()], 50);
        var trabajador = new Worker("Juan", "12345678", DateTime.Now, TypeSpecialty.Carpintero);
        controlAcceso.Enter(trabajador);
        controlAcceso.Exit(trabajador.DocumentNumber, 51);
        controlAcceso.ExitForLunch(trabajador.DocumentNumber);
        controlAcceso.Exit(trabajador.DocumentNumber, 1);

        // Act
        var trabajadorFinalJornada = controlAcceso.GetWorker(trabajador.DocumentNumber);

        trabajadorFinalJornada.CountExit.Should().Be(3);
    }
}