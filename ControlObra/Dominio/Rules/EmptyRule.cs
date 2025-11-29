namespace ControlObra.Dominio.Rules;

public class EmptyRule : IAccessRule
{
    // public string Message => "Ingreso exitoso";

    public string EvaluateAccess(Worker worker)
        => "Ingreso exitoso";
}