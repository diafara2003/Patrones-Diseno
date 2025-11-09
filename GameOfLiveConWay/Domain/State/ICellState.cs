namespace GameOfLiveConWay;

public interface ICellState
{
    bool IsAlive { get; }
    ICellState NextState(int neighbours);
}

