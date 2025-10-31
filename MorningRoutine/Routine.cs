namespace MorningRoutine;

public class Routine(IClock clock)
{
    public string WhatShould()
    {
        var hour = clock.Now.Hour;
        return hour switch
        {
            6 => "Hacer ejercicio",
            7 => "Leer y estudiar",
            _ => "Sin Actividad"
        };
    }
}