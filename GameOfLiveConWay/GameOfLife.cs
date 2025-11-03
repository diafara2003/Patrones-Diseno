namespace GameOfLiveConWay;

public class GameOfLife
{
    private readonly int _rows;
    private readonly int _cells;
    private readonly bool[,] _grid;

    public GameOfLife(int rows, int cells)
    {
        if (IsInvalidGrid(rows, cells))
            throw new IndexOutOfRangeException("Los valores de las celdas deben ser mayores a cero");

        _rows = rows;
        _cells = cells;
        _grid = new bool[rows, cells];
    }

    public bool IsALive(int row, int cell)
    {
        return _grid[row, cell];
    }

    public int CountNeighbor(int row, int cell)
    {
        return 0;
    }

    private bool IsInvalidGrid(int row, int cell)
    {
        return row <= 0 || cell <= 0;
    }

    public void SetAlive(int row, int cell)
    {
        if (row > _rows && cell > _cells)
            throw new IndexOutOfRangeException(
                $"El valor de las celdas debe estar dentro de los limites row:{_rows}-cell:{_cells}");

        _grid[row, cell] = true;
    }
}