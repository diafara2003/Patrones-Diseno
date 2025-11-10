namespace GameOfLiveConWay;

public class DeadCell : ICell
{
    public bool IsAlive => false;

    public ICell NextState(int neighbours)
    {
        return neighbours is 3 ? new AliveCell() : this;
    }
}