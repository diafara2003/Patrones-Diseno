namespace GameOfLiveConWay;

public class DeadState : ICellState
{
    public bool IsAlive => false;

    public ICellState NextState(int neighbours)
    {
        return neighbours is 3 ? new AliveState() : this;
    }
}