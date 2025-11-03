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
    
    public void SetAlive(int row, int cell)
    {
        if (row > _rows && cell > _cells)
            throw new IndexOutOfRangeException(
                $"El valor de las celdas debe estar dentro de los limites row:{_rows}-cell:{_cells}");

        _grid[row, cell] = true;
    }

    public void NextGen()
    {
        var nextGen = new bool[_rows, _cells];
        for (var row = 0; row < _rows; row++)
        {
            for (var cell = 0; cell < _cells; cell++)
            {
                var aliveNeighbours = CountNeighbor(row, cell);


                if (IsALive(row, cell))
                    //regla 1. muere por infrapoblacion <2
                    //regla 2. vive por sobrevivencia 2 o 3
                    nextGen[row, cell] = IsCellLife(aliveNeighbours);
                else
                    //regla 4. nace por reproduccion 
                    nextGen[row, cell] = IsCellBornWhenCellDie(aliveNeighbours);
            }
        }

        Array.Copy(nextGen, _grid, nextGen.Length);
    }

    public int CountNeighbor(int row, int cell)
    {
        var count = 0;

        var minRows = MinPosition(row);
        var maxRows = MaxPosition(row);

        var minCells = MinPosition(cell);
        var maxCells = MaxPosition(cell);

        for (var rowPosition = minRows; rowPosition <= maxRows; rowPosition++)
        {
            if (IsPositionOutside(rowPosition, _rows))
                continue;

            for (var cellPosition = minCells; cellPosition <= maxCells; cellPosition++)
            {
                if (ShouldSkipCell(row, rowPosition, cell, cellPosition))
                    continue;

                if (IsALive(rowPosition, cellPosition))
                    count++;
            }
        }


        return count;
    }

    private bool ShouldSkipCell(int targetRow, int currentRow, int targetCell, int currentCell)
    {
        return IsPositionOutside(currentCell, _cells) ||
               IsSamePosition(targetRow, currentRow,targetCell, currentCell);
    }

    private static int MaxPosition(int currentPosition)
    {
        return currentPosition + 1;
    }

    private static int MinPosition(int currentPosition)
    {
        return currentPosition - 1;
    }

    private static bool IsPositionOutside(int position, int limit)
    {
        return position <= -1 || position >= limit;
    }


    private bool IsSamePosition(int targetRow, int currentRow,int targetCell,  int currentCell)
    {
        return currentRow == targetRow && currentCell == targetCell;
    }

   
    private bool IsInvalidGrid(int row, int cell)
    {
        return row <= 0 || cell <= 0;
    }

   
    private static bool IsCellBornWhenCellDie(int count)
    {
        return count == 3;
    }

    private static bool IsCellLife(int count)
    {
        return (count is 2 or 3);
    }
}