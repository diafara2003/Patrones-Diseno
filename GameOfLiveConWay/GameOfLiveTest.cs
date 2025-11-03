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
        var vecinos = gameOfLive.CountNeighbor(1,1);

        vecinos.Should().Be(0);
    }
}