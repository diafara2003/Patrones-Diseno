namespace GameOfLiveConWay;

public class Cell(ICellState state)
{
    public bool IsAlive => state.IsAlive;

    public void Update(int neighbours)
    {
        state.NextState(neighbours);
    }
}