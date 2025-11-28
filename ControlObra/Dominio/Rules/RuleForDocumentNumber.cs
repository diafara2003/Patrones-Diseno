namespace ControlObra.Dominio;

public class RuleForDocumentNumberEven() : IAccessRule
{
    public string Message { get; private set; } = "";

    public bool HasAccess(Worker worker)
    {
        var isError = int.Parse(worker.documentNumber.Last().ToString()) % 2 == 0;

        if (isError is false)
            Message = "No cumple con la regla de cedula";

        return isError;
    }
}