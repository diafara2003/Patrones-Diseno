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
}

public class GameOfLife
{
    public GameOfLife(int rows, int cells)
    {
        throw new NotImplementedException();
    }

    public bool IsALive(int row, int cell)
    {
        throw new NotImplementedException();
    }
}