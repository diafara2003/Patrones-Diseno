namespace MorningRoutine;

public class Routine(IClock clock)
{
    public string WhatShould()
    {
        var hour = clock.Now.Hour;
        if (hour == 6)  
            return "Hacer ejercicio";


        if (hour == 7)
            return "Leer y estudiar";

        return "Sin Actividad";
    }
}