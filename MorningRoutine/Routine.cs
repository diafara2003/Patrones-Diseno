namespace MorningRoutine;

public class Routine(IClock clock)
{

    
    public string WhatShould()
    {
        var hour = GetNowHour();
        return hour switch
        {
            6 => "Hacer ejercicio",
            7 => "Leer y estudiar",
            8 => "Desayunar",
            _ => "Sin Actividad"
        };
    }

    private int GetNowHour()
    {
        return clock.Now.Hour;
    }
}