namespace GameOfLiveConWay;

public interface ICell
{
    bool IsAlive { get; }
    ICell NextState(int neighbours);
}

