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

    private List<Activity> DefaultActivities =>
    [
        new Activity(new TimeSpan(6, 0, 0), new TimeSpan(6, 59, 0), "Hacer ejercicio"),
        new Activity(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 0), "Leer y estudiar"),
        new Activity(new TimeSpan(7, 0, 0), new TimeSpan(8, 59, 0), "Desayunar")
    ];

    public string WhatShouldNow()
    {
        var time = GetTimeNow();
        var activity = _activities.FirstOrDefault(activity => activity.ContainsTime(time));

        return activity?.Description ?? "No hay actividad";
    }

    private TimeSpan GetTimeNow()
    {
        return _clock.Now.TimeOfDay;
    }

    public void AddActivity(Activity newActivity)
    {
        _activities.Add(newActivity);
    }
}