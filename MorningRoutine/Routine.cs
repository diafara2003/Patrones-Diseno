namespace MorningRoutine;

public class Routine
{
    private readonly List<Activity> _activities;
    private readonly IClock _clock;

    public Routine(IClock clock)
    {
        _clock = clock;
        _activities = DefaultActivities;
    }


    public string WhatShouldNow()
    {
        var time = GetTimeNow();
        var activity = _activities.FirstOrDefault(activity => activity.ContainsTime(time));

        return activity?.Description ?? "No hay actividad";
    }


    public void AddActivity(Activity newActivity)
    {
        if (HasTimeActivity(newActivity.Start))
            throw new ArgumentException("Ya existe una actividad en ese horario");

        _activities.Add(newActivity);
    }

    public void UpdateActivity(Activity newActivity, TimeSpan start, TimeSpan end, string name)
    {
        if (HasTimeActivity(newActivity.Start))
        {
            _activities.Remove(newActivity);
            _activities.Add(new Activity(start, end, name));
        }
    }

    private List<Activity> DefaultActivities =>
    [
        new Activity(new TimeSpan(6, 0, 0), new TimeSpan(6, 59, 0), "Hacer ejercicio"),
        new Activity(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 0), "Leer y estudiar"),
        new Activity(new TimeSpan(7, 0, 0), new TimeSpan(8, 59, 0), "Desayunar")
    ];

    private bool HasTimeActivity(TimeSpan start)
    {
        return _activities.Any(activity => activity.ContainsTime(start));
    }

    private TimeSpan GetTimeNow()
    {
        return _clock.Now.TimeOfDay;
    }
}