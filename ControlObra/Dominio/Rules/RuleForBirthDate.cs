namespace ControlObra.Dominio;

public class RuleForBirthDate : IAccessRule
{
    public string Message { get; private set; } = "";

    public bool HasAccess(Worker worker)
    {
        var isAccess = worker.birthDate.Month == DateTime.Now.Month
                       && worker.birthDate.Day == DateTime.Now.Day;

        if (isAccess is false)
            Message = "No cumple con la regla de cumpleaños";

        return isAccess;
    }
}