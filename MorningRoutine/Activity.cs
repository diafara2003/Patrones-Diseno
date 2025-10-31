namespace MorningRoutine;

public record Activity(TimeSpan Start, TimeSpan End, string Description)
{
    public bool ContainsTime(TimeSpan time)
    {
        return time >= Start && time <= End;
    }
}