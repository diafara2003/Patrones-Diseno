namespace MorningRoutine;

public class FakeClock(DateTime now) : IClock
{
    public DateTime Now { get; } = now;
}