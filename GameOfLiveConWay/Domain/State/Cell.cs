namespace GameOfLiveConWay;

public class Cell(ICell state)
{
    public bool IsAlive => state.IsAlive;
}