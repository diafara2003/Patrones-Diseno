namespace ControlObra.Dominio.Rules;

public class RuleForProgress : IAccessRule
{
    public string EvaluateRule(Worker worker)
    {
        var isAccess = worker.Progress > 50;

        return isAccess is false ? "No cumple con la regla de progreso" : "";
    }
}