namespace GameOfLiveConWay;

public class AliveCell : ICell
{
    public bool IsAlive => true;

    public ICell NextState(int neighbours)
    {
        return neighbours is 2 or 3 ? this : new DeadCell();
    }
}