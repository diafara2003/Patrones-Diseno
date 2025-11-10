namespace GameOfLiveConWay;

public static class CalulatorPosition
{
    public static int CountNeighborAlive(this ICell[,] grid, int row, int cell)
    {
        var count = 0;
        var position = new Coordinate(row, cell);

        var positionRow = position.CalculateLimit(row);
        var positionCell = position.CalculateLimit(cell);

        for (var rowPosition = positionRow.X; rowPosition <= positionRow.Y; rowPosition++)
        {
            if (IsPositionOutside(rowPosition, grid.GetLength(0)))
                continue;

            for (var cellPosition = positionCell.X; cellPosition <= positionCell.Y; cellPosition++)
            {
                if (ShouldSkipCell(row, rowPosition, cell, cellPosition, grid.GetLength(1)))
                    continue;

                if (grid[rowPosition, cellPosition].IsAlive)
                    count++;
            }
        }


        return count;
    }

    private static bool ShouldSkipCell(int targetRow, int currentRow, int targetCell, int currentCell, int maxCellsGrid)
    {
        return IsPositionOutside(currentCell, maxCellsGrid) ||
               IsSamePosition(targetRow, currentRow, targetCell, currentCell);
    }

    private static bool IsSamePosition(int targetRow, int currentRow, int targetCell, int currentCell) =>
        currentRow == targetRow && currentCell == targetCell;

    private static bool IsPositionOutside(int position, int limit) => position <= -1 || position >= limit;
}