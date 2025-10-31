using FluentAssertions;

namespace MorningRoutine;

public class MorningRoutineTest
{
    [Fact]
    public void SiLaHoraES6_Debe_MostrarHacerEjercicio()
    {
        // Arrange
        var clock = new FakeClock(new DateTime(2025, 1, 1, 6, 0, 0));
        var routine = new Routine(clock);
        // Act
        var resultado = routine.WhatShould();
        //Assert
        resultado.Should().Be("Hacer ejercicio");
    }

    [Fact]
    public void SiLaHoraEs7_Debe_MostrarLeerEstudiar()
    {
        //Arrange
        var clock = new FakeClock(new DateTime(2025, 1, 1, 7, 0, 0));
        var routine = new Routine(clock);

        //Act
        var resultado = routine.WhatShould();

        //Assert
        resultado.Should().Be("Leer y estudiar");
    }
}