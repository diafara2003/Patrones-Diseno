namespace ControlObra.Dominio.Rules;

public class RuleForSpecialty(TypeSpecialty typeSpecialty) : IAccessRule
{
    // public string Message { get; private set; } = "";

    public string EvaluateAccess(Worker worker)
    {
        var isAccess = worker.speciality == typeSpecialty;

        return isAccess is false ? "No cumple con la regla de especialidad" : "";
    }
}