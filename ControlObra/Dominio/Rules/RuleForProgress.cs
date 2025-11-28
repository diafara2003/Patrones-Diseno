namespace ControlObra.Dominio;

public class RuleForProgress : IAccessRule
{
    public string Message { get; private set; } = "";

    public bool HasAccess(Worker worker)
    {
        var isAccess = worker.progress > 50;

        if (isAccess is false)
            Message = "No cumple con la regla de progreso";

        return isAccess;
    }
}