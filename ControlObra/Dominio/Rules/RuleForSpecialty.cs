namespace ControlObra.Dominio.Rules;

public class RuleForSpecialty(TypeSpecialty typeSpecialty) : IAccessRule
{
    public string EvaluateAccess(Worker worker)
    {
        var isAccess = worker.speciality == typeSpecialty;

        return isAccess is false ? "No cumple con la regla de especialidad" : "";
    }
}