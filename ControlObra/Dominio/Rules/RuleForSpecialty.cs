namespace ControlObra.Dominio.Rules;

public class RuleForSpecialty(TypeSpecialty typeSpecialty) : IAccessRule
{
    public string EvaluateRule(Worker worker)
    {
        var isAccess = worker.Speciality == typeSpecialty;

        return isAccess is false ? "No cumple con la regla de especialidad" : "";
    }
}