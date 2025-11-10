using FluentAssertions;

namespace GameOfLiveConWay;

public class CalculatorPositionTest
{
    [Theory]
    [MemberData(nameof(GetCoordenadaTestData))]
    public void ValidarVecinosCelulaViva(SizeGrid size, Alive alive, Coordenada Coordenada)
    {
        //arrange
        var gridBuilder = new GridBuilder();
        var calculator = gridBuilder
            .WithGrid(size.row, size.col) //centro
            .WithCellAlive(alive.row, alive.row)
            .WithCellAlive(Coordenada.row, Coordenada.row)
            .Build();


        //act
        var vecinos = calculator.CountNeighborAlive(alive.row, alive.col);

        //assert
        vecinos.Should().Be(1);
    }

    [Fact]
    public void ValidarLimitesCountCoordenada()
    {
        //arrange
        var gridBuilder = new GridBuilder();
        var calculator = gridBuilder
            .WithGrid(3, 3) //centro
            .WithCellAlive(0, 2)
            .Build();

        //act
        var vecinos = calculator.CountNeighborAlive(0, 2);

        //assert
        vecinos.Should().Be(0);
    }

    [Fact]
    public void ContarVecinos_EnTableroVacio_DebeSerCero()
    {
        //Arrange
        var gridBuilder = new GridBuilder();
        var calculator = gridBuilder
            .WithGrid(3, 3) //centro
            .WithCellAlive(1, 1)
            .Build();

        //Act
        var vecinos = calculator.CountNeighborAlive(1, 1);

        vecinos.Should().Be(0);
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
}