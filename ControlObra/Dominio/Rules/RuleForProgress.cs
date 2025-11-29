namespace ControlObra.Dominio.Rules;

public class RuleForProgress : IAccessRule
{
    public string EvaluateAccess(Worker worker)
    {
        var isAccess = worker.progress > 50;

        return isAccess is false ? "No cumple con la regla de progreso" : "";
    }
}