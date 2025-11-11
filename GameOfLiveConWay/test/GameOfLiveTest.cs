using FluentAssertions;

namespace GameOfLiveConWay;

public class GameOfLiveTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    public void InicializarGridYTodasLasCeldasMuertas(int row, int cell)
    {
        //Arrange 
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        var isALive = gameOfLive.IsALive(row, cell);

        //Assert
        isALive.Should().BeFalse();
    }


    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    public void EstablecerCeldaViva(int row, int cell)
    {
        //Arrange
        var gameOfLive = new GameOfLife(3, 3);

        //Act
        gameOfLive.SetCellAlive(row, cell);

        gameOfLive.IsALive(row, cell).Should().BeTrue();
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