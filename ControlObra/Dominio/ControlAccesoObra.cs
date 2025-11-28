namespace ControlObra.Dominio;

public class ControlAccesoObra
{
    private readonly List<Worker> _employs = [];

    private bool RuleForOnlyEmploysCategory(Worker employ) => employ.speciality == TypeSpecialty.Carpintero;

    private bool RuleForOnlyDocument(Worker employ) => int.Parse(employ.document) % 2 == 0;

    private bool RuleForOnlyEmployProgress(Worker employ) => employ.progress >= 50;

    public bool SignIn(Worker employ)
    {
        if (RuleForOnlyEmploysCategory(employ) is false)
            return false;

        if (RuleForOnlyDocument(employ) is false)
            return false;

        if (RuleForOnlyEmployProgress(employ) is false)
            return false;

        _employs.Add(employ);
        return true;
    }
}