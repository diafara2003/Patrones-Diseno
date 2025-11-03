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
        var count = 0;

        var initialRow = row - 1;
        var initialCell = cell - 1;
        var finalRow = row + 1;
        var finalCell = cell + 1;
        for (var r = initialRow; r <= finalRow; r++)
        {
            if (IsBoundContext(r, _rows)) continue;
            for (var c = initialCell; c <= finalCell; c++)
            {
                if (IsBoundContext(c, _cells) || IsSkipCurrentCell(row, cell, r, c))
                    continue;

                if (IsALive(r, c))
                    count++;
            }
        }


        return count;
    }

    private static bool IsBoundContext(int position, int limit)
    {
        return position <= -1 || position >= limit;
    }


    private bool IsSkipCurrentCell(int row, int cell, int r, int c)
    {
        return r == row && c == cell;
    }

    public void SetAlive(int row, int cell)
    {
        if (row > _rows && cell > _cells)
            throw new IndexOutOfRangeException(
                $"El valor de las celdas debe estar dentro de los limites row:{_rows}-cell:{_cells}");

        _grid[row, cell] = true;
    }

    private bool IsInvalidGrid(int row, int cell)
    {
        return row <= 0 || cell <= 0;
    }
}