namespace GameOfLiveConWay;

public class Coordinate(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public Coordinate CalculateLimit(int currentPosition)
    {
        var minPosition = currentPosition - 1;
        var maxPosition = currentPosition + 1;

        return new Coordinate(minPosition, maxPosition);
    }
}