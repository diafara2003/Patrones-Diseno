namespace GameOfLiveConWay;

public class GridBuilder
{
    private ICell[,] _grid;


    public GridBuilder WithGrid(int rows, int cells)
    {
        _grid = CreateGrid(rows, cells);
        return this;
    }

    public GridBuilder WithCellAlive(int row, int cell)
    {
        _grid[row, cell] = new AliveCell();

        return this;
    }

    public ICell[,] Build() => _grid;

    private ICell[,] CreateGrid(int rows, int cells)
    {
        var grid = new ICell[rows, cells];

        for (var row = 0; row < rows; row++)
        {
            for (var cell = 0; cell < cells; cell++)
            {
                grid[row, cell] = new DeadCell();
            }
        }

        return grid;
    }
}