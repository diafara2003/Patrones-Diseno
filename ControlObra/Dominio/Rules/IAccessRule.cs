namespace ControlObra.Dominio.Rules;

public interface IAccessRule
{
    // string Message { get; }
    string EvaluateAccess(Worker worker);
}