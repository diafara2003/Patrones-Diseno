using ControlObra.Dominio.Rules;

namespace ControlObra.Dominio;

public class ControlAccesoObra(List<IAccessRule> rules, int minProgress)
{
    public readonly List<Worker> workers = [];
    private List<LogExit> _exitLogs = [];


    public string Enter(Worker employ)
    {
        var accessRules = rules
            .Select(rule => rule.EvaluateRule(employ))
            .ToList();


        var messageFormat = FormatErrorMessages(accessRules);

        if (accessRules.Any())
            return FormatErrorMessages(accessRules);


        workers.Add(employ);

        return messageFormat;
    }

    private string FormatErrorMessages(List<string> rulesError)
    {
        return rulesError
            .Aggregate((current, next) => current + ", " + next);
    }

    public bool Exit(string documentNumber, int progress, ExitType exitType)
    {
        if (exitType == ExitType.Lunch)
        {
            _exitLogs.Add(new LogExit(documentNumber, progress, exitType));
            return true;
        }

        if (progress < minProgress)
            return false;

        return true;
    }
}

public enum ExitType
{
    Lunch,
    Other
}