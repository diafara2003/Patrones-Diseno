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
    public void EstablecerCeldaViva()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        gameOfLive.SetCellAlive(1, 1);

        gameOfLive.IsALive(1, 1).Should().BeTrue();
    }

    [Fact]
    public void ALSetearCeldaVivaYSuperaGrid_Debe_GenerarUnaExcepcion()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        var caller = () => gameOfLive.SetCellAlive(4, 4);

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
    public void UnaCelulaViva_ConMenosDe2Vecinos_Muere()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetCellAlive(0, 0); //centro

        //Act
        gameOfLive.NextGen();

        //Arrange
        gameOfLive.IsALive(0, 0).Should().BeFalse();
    }

    [Fact]
    public void CelulaVivaConDosVecinosPermaneceViva()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetCellAlive(1, 1); //celula viva
        gameOfLive.SetCellAlive(1, 0); //venino
        gameOfLive.SetCellAlive(1, 2); //vecino

        //Act
        gameOfLive.NextGen();

        //Arrange
        gameOfLive.IsALive(1, 1).Should().BeTrue();
    }

    [Fact]
    public void CelulaVivaConUnVecino_DebeMorirEnSiguienteGeneracion()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetCellAlive(1, 1); //celula viva
        gameOfLive.SetCellAlive(1, 0); //venino

        //Act
        gameOfLive.NextGen();

        //Arrange
        gameOfLive.IsALive(1, 1).Should().BeFalse();
    }

    [Fact]
    public void CelulaMuertaConTresVecinosDebeNacer()
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetCellAlive(1, 1);
        gameOfLive.SetCellAlive(1, 0);
        gameOfLive.SetCellAlive(1, 2);
        gameOfLive.NextGen();

        //Act
        gameOfLive.NextGen();

        //Arrange
        gameOfLive.IsALive(1, 1).Should().BeTrue();
    }
}

public record SizeGrid(int row, int col);

public record Alive(int row, int col);

public record Coordenada(int row, int col);