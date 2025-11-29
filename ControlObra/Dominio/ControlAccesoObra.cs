namespace ControlObra.Dominio;

public class ControlAccesoObra(List<IAccessRule> rules)
{
    private readonly List<Worker> _workers = [];


    public string Enter(Worker employ)
    {
        var accessRules = rules
            .Where(rule => !rule.HasAccess(employ))
            .ToList();


        var messageFormat = FormatErrorMessages(accessRules);

        if (accessRules.Any())
            return FormatErrorMessages(accessRules);


        _workers.Add(employ);

        return messageFormat;
    }

    private string FormatErrorMessages(List<IAccessRule> rulesError)
    {
        if (rulesError.Count == 0)
            return "Ingreso exitoso";

        return rulesError.Select(ruleMessage => ruleMessage.Message)
            .Aggregate((current, next) => current + ", " + next);
    }
}