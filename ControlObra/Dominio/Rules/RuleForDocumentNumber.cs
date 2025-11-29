namespace ControlObra.Dominio;

public class RuleForDocumentNumberEven() : IAccessRule
{
    // public string Message { get; private set; } = "";

    public string EvaluateAccess(Worker worker)
    {
        var isError = int.Parse(worker.documentNumber.Last().ToString()) % 2 == 0;

        return isError is false ? "No cumple con la regla de cedula" : "";
    }
}