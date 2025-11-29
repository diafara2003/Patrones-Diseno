namespace ControlObra.Dominio.Rules;

public class EmptyRule : IAccessRule
{
    public string EvaluateAccess(Worker worker)
        => "Ingreso exitoso";
}