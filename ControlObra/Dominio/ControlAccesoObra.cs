namespace ControlObra.Dominio;

public class ControlAccesoObra
{
    private readonly List<Worker> _employs = [];

   
    public bool SignIn(Worker employ)
    {
        _employs.Add(employ);
        return true;
    }
}