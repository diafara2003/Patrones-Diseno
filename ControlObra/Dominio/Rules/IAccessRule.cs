namespace ControlObra.Dominio;

public interface IAccessRule
{
    string Message { get; }
    bool HasAccess(Worker worker);
}