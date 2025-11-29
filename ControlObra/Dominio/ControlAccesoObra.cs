using ControlObra.Dominio.Rules;

namespace ControlObra.Dominio;

public class ControlAccesoObra(List<IAccessRule> rules, int minProgress)
{
    public readonly List<Worker> workers = [];
    private List<LogExit> _exitLogs = [];


    public string Enter(Worker employ)
    {
        var accessRules = EvaluateAccessRules(employ);

        var messageFormat = FormatErrorMessages(accessRules);

        if (IsRuleSuccess(accessRules, messageFormat))
            workers.Add(employ);

        if (accessRules.Any())
            return FormatErrorMessages(accessRules);


        return messageFormat;
    }


    private List<string> EvaluateAccessRules(Worker employ)
    {
        return rules
            .Select(rule => rule.EvaluateRule(employ))
            .ToList();
    }


    public bool Exit(string documentNumber, int progress, ExitType exitType)
    {
        if (exitType == ExitType.Lunch)
        {
            _exitLogs.Add(new LogExit(documentNumber, progress, exitType));
            return true;
        }

        var worker = workers.FirstOrDefault(worker => worker.documentNumber == documentNumber);

        if (worker is null)
            throw new InvalidOperationException("El trabajador no existe");

        var totalProgressWorker = TotalProgressWorker(documentNumber, progress, worker);

        if (IsProgressSufficient(totalProgressWorker))
            return false;


        _exitLogs.Add(new LogExit(documentNumber, totalProgressWorker, exitType));
        return true;
    }

    private bool IsProgressSufficient(int totalProgressWorker)
        => totalProgressWorker < minProgress;

    private bool IsRuleSuccess(List<string> accessRules, string messageFormat)
        =>
            accessRules.Count == 1 && messageFormat == "Ingreso exitoso";

    private int TotalProgressWorker(string documentNumber, int progress, Worker worker)
    {
        var logProgress = _exitLogs
            .Where(log => log.documentNumber == documentNumber)
            .Sum(log => log.progress);

        var totalProgressWorker = progress + worker.progress + logProgress;
        return totalProgressWorker;
    }

    private string FormatErrorMessages(List<string> rulesError)
        => rulesError
            .Aggregate((current, next) => $"{current}, {next}");
}

public enum ExitType
{
    Lunch,
    Other
}