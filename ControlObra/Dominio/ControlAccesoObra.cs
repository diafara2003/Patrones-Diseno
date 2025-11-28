namespace ControlObra.Dominio;

public class ControlAccesoObra
{
    public static string IngresoExitoso = "Ingreso exitoso";

    private List<IAccessRule> _rules = [];
    private readonly List<Worker> _employs = [];

    public void AddRule(IAccessRule rule) => _rules.Add(rule);


    public string Enter(Worker employ)
    {
        if (_rules.Count == 0)
            return IngresoExitoso;

        var rulesError = _rules
            .Where(rule => !rule.HasAccess(employ))
            .ToList();

        if (rulesError.Any())
            return FormatErrorMessages(rulesError);


        _employs.Add(employ);

        return IngresoExitoso;
    }

    private static string FormatErrorMessages(IEnumerable<IAccessRule> rulesError)
    {
        return rulesError.Select(ruleMessage => ruleMessage.Message)
            .Aggregate((current, next) => current + ", " + next);
    }
}