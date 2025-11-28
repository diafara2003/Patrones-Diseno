namespace ControlObra.Dominio;

public class RuleForSpecialty(TypeSpecialty typeSpecialty) : IAccessRule
{
    public string Message { get; private set; } = "";

    public bool HasAccess(Worker worker)
    {
        var isAccess = worker.speciality == typeSpecialty;

        if (isAccess is false)
            Message = "No cumple con la regla de especialidad";
        return isAccess;
    }
}