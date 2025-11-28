namespace ControlObra.Dominio;

public class ControlAccesoObra
{
    private readonly List<Worker> _employs = [];

    private bool RuleForOnlyEmploysCategory(Worker employ) => employ.speciality == TypeSpecialty.Carpintero;

    public bool SignIn(Worker employ)
    {
        if (RuleForOnlyEmploysCategory(employ) is false)
            return false;

        _employs.Add(employ);
        return true;
    }
}