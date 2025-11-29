namespace ControlObra.Dominio.Rules;

public class EmptyRule : IAccessRule
{
    public string Message => "Ingreso exitoso";

    public bool HasAccess(Worker worker)
        => true;
}