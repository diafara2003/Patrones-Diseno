namespace GameOfLiveConWay;

public class Position(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public Position CalculateLimit(int currentPosition)
    {
        var minPosition = currentPosition - 1;
        var maxPosition = currentPosition + 1;

        return new Position(minPosition, maxPosition);
    }
}