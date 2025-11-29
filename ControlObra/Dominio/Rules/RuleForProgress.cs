namespace ControlObra.Dominio;

public class RuleForProgress : IAccessRule
{
    // public string Message { get; private set; } = "";

    public string EvaluateAccess(Worker worker)
    {
        var isAccess = worker.progress > 50;

        return isAccess is false ? "No cumple con la regla de progreso" : "";
    }
}