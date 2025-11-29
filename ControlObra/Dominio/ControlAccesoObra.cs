using ControlObra.Dominio.Rules;

namespace ControlObra.Dominio;

public class ControlAccesoObra(List<IAccessRule> rules)
{
    private readonly List<Worker> _workers = [];


    public string Enter(Worker employ)
    {
        var accessRules = rules
            .Select(rule => rule.EvaluateAccess(employ))
            .ToList();


        var messageFormat = FormatErrorMessages(accessRules);

        if (accessRules.Any())
            return FormatErrorMessages(accessRules);


        _workers.Add(employ);

        return messageFormat;
    }

    private string FormatErrorMessages(List<string> rulesError)
    {
        return rulesError
            .Aggregate((current, next) => current + ", " + next);
    }
}