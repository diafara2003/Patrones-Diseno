namespace GameOfLiveConWay;

public class GameOfLife
{
    private readonly ICell[,] _grid;
    private readonly int _rows;
    private readonly int _cells;
   
    public GameOfLife(int rows, int cells)
    {
        ThrowArgumentInvalid(rows, cells);

        _rows = rows;
        _cells = cells;
        _grid = InitializeGrid(rows, cells);
    }


    private void ThrowArgumentInvalid(int rows, int cells)
    {
        if (IsInvalidGrid(rows, cells))
            throw new IndexOutOfRangeException("Los valores de las celdas deben ser mayores a cero");
    }

    public bool IsALive(int row, int cell) => _grid[row, cell].IsAlive;


    public void NextGen()
    {
        var newGrid = new ICell[_rows, _cells];
       
        for (var row = 0; row < _rows; row++)
        {
            for (var cell = 0; cell < _cells; cell++)
            {
                var aliveNeighbours = _grid.CountNeighborAlive(row, cell);

                var current = _grid[row, cell];

                var newCellState = current.NextState(aliveNeighbours);
                newGrid[row, cell] = newCellState;
            }
        }

        Array.Copy(newGrid, _grid, newGrid.Length);
    }

    public void SetCellAlive(int row, int cell)
    {
        ThrowIfCellIndexOutOfRange(row, cell);

        _grid[row, cell] = new AliveCell();
    }

    private void ThrowIfCellIndexOutOfRange(int row, int cell)
    {
        if (ValidateCellIndex(row, cell))
            throw new IndexOutOfRangeException(
                $"El valor de las celdas debe estar dentro de los limites row:{_rows}-cell:{_cells}");
    }


    private ICell[,] InitializeGrid(int rows, int cells)
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

    private bool ValidateCellIndex(int row, int cell) => row < 0 || row >= _rows || cell < 0 || cell >= _cells;

    private bool IsInvalidGrid(int row, int cell) => row <= 0 || cell <= 0;
}