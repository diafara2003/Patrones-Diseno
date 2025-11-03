namespace GameOfLiveConWay;

public class GameOfLifeRefactor(int rows, int cells)
{
    private readonly Cell[,] _grid = new Cell[rows, cells];


    public void NextGen()
    {
        var newGrid = new Cell[rows, cells];

        for (int row = 0; row < rows; row++)
        {
            for (int cell = 0; cell < cells; cell++)
            {
                var aliveNeighbours = CountNeighbor(row, cell);

                ICellState currentState = _grid[row, cell].IsAlive
                    ? new AliveState()
                    : new DeadState();

                var newCell = new Cell(currentState);
                newCell.Update(aliveNeighbours);
                newGrid[row, cell] = newCell;
            }
        }

        Array.Copy(newGrid, _grid, newGrid.Length);
    }

    public bool IsALive(int row, int cell)
    {
        return _grid[row, cell].IsAlive;
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
            if (IsPositionOutside(rowPosition, rows))
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
        return IsPositionOutside(currentCell, cells) ||
               IsSamePosition(targetRow, currentRow, targetCell, currentCell);
    }

    private bool IsSamePosition(int targetRow, int currentRow, int targetCell, int currentCell)
    {
        return currentRow == targetRow && currentCell == targetCell;
    }

    private static bool IsPositionOutside(int position, int limit)
    {
        return position <= -1 || position >= limit;
    }

    private static int MaxPosition(int currentPosition)
    {
        return currentPosition + 1;
    }

    private static int MinPosition(int currentPosition)
    {
        return currentPosition - 1;
    }
}