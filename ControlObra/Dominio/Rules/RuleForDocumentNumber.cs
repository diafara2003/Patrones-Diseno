namespace ControlObra.Dominio.Rules;

public class RuleForDocumentNumberEven() : IAccessRule
{
    public string EvaluateRule(Worker worker)
    {
        var isError = int.Parse(worker.DocumentNumber.Last().ToString()) % 2 == 0;

        return isError is false ? "No cumple con la regla de cedula" : "";
    }
}