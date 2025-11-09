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
        var vecinos = gameOfLive.CountNeighborAlive(1, 1);

        vecinos.Should().Be(0);
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

    public static IEnumerable<object[]> GetCoordenadaTestData()
    {
        //Vecino arriba,
        yield return
        [
            new SizeGrid(3, 3),
            new Alive(1, 1),
            new Coordenada(0, 1)
        ];
        //Vecino abajo,
        yield return
        [
            new SizeGrid(3, 3),
            new Alive(1, 1),
            new Coordenada(2, 1)
        ];
        //Vecino A la derecha,
        yield return
        [
            new SizeGrid(3, 3),
            new Alive(0, 1),
            new Coordenada(0, 2)
        ];
        //Vecino A la izquierda,
        yield return
        [
            new SizeGrid(3, 3),
            new Alive(1, 1),
            new Coordenada(0, 0)
        ];
    }


    [Theory]
    [MemberData(nameof(GetCoordenadaTestData))]
    public void ValidarVecinosCelulaViva(SizeGrid size, Alive alive, Coordenada Coordenada)
    {
        //arrange
        var gameOfLive = new GameOfLife(size.row, size.col);
        gameOfLive.SetCellAlive(alive.row, alive.col); //centro
        gameOfLive.SetCellAlive(Coordenada.row, Coordenada.col);

        //act
        var vecinos = gameOfLive.CountNeighborAlive(alive.row, alive.col);

        //assert
        vecinos.Should().Be(1);
    }

    [Fact]
    public void ValidarLimitesCountCoordenada()
    {
        //arrange
        var gameOfLive = new GameOfLife(3, 3);
        gameOfLive.SetCellAlive(0, 2); //centro

        //act
        var vecinos = gameOfLive.CountNeighborAlive(0, 2);

        //assert
        vecinos.Should().Be(0);
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