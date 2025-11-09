namespace GameOfLiveConWay;

public class Cell(ICellState state)
{
    public bool IsAlive => state.IsAlive;
}