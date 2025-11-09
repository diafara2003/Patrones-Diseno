namespace GameOfLiveConWay;

public class Position(int min, int max)
{
    public int Min { get; } = min;
    public int Max { get; } = max;

    public Position GetPosition(int currentPosition)
    {
        var minPosition = currentPosition - 1;
        var maxPosition = currentPosition + 1;

        return new Position(minPosition, maxPosition);
    }
}