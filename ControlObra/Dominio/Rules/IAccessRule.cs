namespace ControlObra.Dominio;

public interface IAccessRule
{
    // string Message { get; }
    string EvaluateAccess(Worker worker);
}