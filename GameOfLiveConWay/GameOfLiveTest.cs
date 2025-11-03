using FluentAssertions;

namespace GameOfLiveConWay;

public class GameOfLiveTest
{
    [Fact]
    public void InicializarGridYTodasLasCeldasMuertas()
    {
        //Arrange 
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        var isALive = gameOfLive.IsALive(0, 0);

        //Assert
        isALive.Should().BeFalse();
    }

    [Fact]
    public void ContarVecinos_EnTableroVacio_DebeSerCero()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        var vecinos = gameOfLive.CountNeighbor(1, 1);

        vecinos.Should().Be(0);
    }

    [Fact]
    public void EstablecerCeldaViva()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        gameOfLive.SetAlive(1, 1);

        gameOfLive.IsALive(1, 1).Should().BeTrue();
    }

    [Fact]
    public void ALSetearCeldaVivaYSuperaGrid_Debe_GenerarUnaExcepcion()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        var caller = () => gameOfLive.SetAlive(4, 4);

        //Assert
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("el valor de las celdas debe estar dentro de los limites row:3-cell:3");
    }

    [Fact]
    public void AlIniciarElJuego_Debe_SerPositivoRowsYCells()
    {
        //Arrange
        var caller = () => new GameOfLife(-1, -1);

        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Los valores de las celdas deben ser mayores a cero");
    }

    [Fact]
    public void DosCelulasVivasSeguidasALaDerecha_Debe_RetornarContarVecinos1()
    {
        //arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetAlive(1, 1);
        gameOfLive.SetAlive(1, 2);
        
        //act
        var vecinos = gameOfLive.CountNeighbor(1, 1);
        
        //assert
        vecinos.Should().Be(1);
        
    }
}