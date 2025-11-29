namespace ControlObra.Dominio.Rules;

public class EmptyRule : IAccessRule
{
    public string EvaluateRule(Worker worker)
        => "Ingreso exitoso";
}