namespace ControlObra.Dominio.Rules;

public interface IAccessRule
{
    // string Message { get; }
    string EvaluateRule(Worker worker);
}