namespace GameOfLiveConWay;

public class AliveState : ICellState
{
    public bool IsAlive => true;

    public ICellState NextState(int neighbours)
    {
        return neighbours is 2 or 3 ? this : new DeadState();
    }
}