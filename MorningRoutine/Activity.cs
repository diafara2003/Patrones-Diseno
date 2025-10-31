namespace MorningRoutine;

public class Activity(TimeSpan start, TimeSpan end, string description)
{
    public string Description { get; } = description;
    public TimeSpan End { get; } = end;
    public TimeSpan Start { get; } = start;

    public bool ContainsTime(TimeSpan time)
    {
        return time >= Start && time <= End;
    }
}