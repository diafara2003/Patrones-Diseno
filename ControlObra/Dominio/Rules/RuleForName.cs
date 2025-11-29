namespace ControlObra.Dominio.Rules;

public class RuleForName(string letter) : IAccessRule
{
    public string EvaluateRule(Worker worker)
    {
        return (worker.Name.ToLower().StartsWith(letter.ToLower()) is false)
            ? $"No cumple con la regla de nombre, debe empezar por {letter}"
            : "";
    }
}