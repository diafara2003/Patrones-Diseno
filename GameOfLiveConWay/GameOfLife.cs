namespace GameOfLiveConWay;

public class GameOfLife(int rows, int cells)
{
    private readonly int _rows = rows;
    private readonly int _cells = cells;
    private readonly bool[,] _grid = new bool[rows, cells];

    public bool IsALive(int row, int cell)
    {
        return _grid[row, cell];
    }

    public int CountNeighbor(int row, int cell)
    {
        throw new NotImplementedException();
    }
}