using ControlObra.Dominio.Rules;

namespace ControlObra.Dominio;

public class ControlAccesoObra(List<IAccessRule> rules, int minProgress)
{
    public readonly List<Worker> Workers = [];

    public string Enter(Worker employ)
    {
        var accessRules = EvaluateAccessRules(employ);

        var messageFormat = FormatErrorMessages(accessRules);

        if (IsRuleSuccess(accessRules, messageFormat))
            Workers.Add(employ);

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

    public Worker GetWorker(string documentNumber)
    {
        var worker = Workers.FirstOrDefault(worker => worker.DocumentNumber == documentNumber);

        return worker ?? throw new InvalidOperationException("El trabajador no existe");
    }

    public bool Exit(string documentNumber, int progress, ExitType exitType)
    {
        var worker = Workers.FirstOrDefault(worker => worker.DocumentNumber == documentNumber);

        if (worker is null)
            throw new InvalidOperationException("El trabajador no existe");

        if (exitType == ExitType.Lunch)
        {
            worker.AddLogExit(new LogExit(documentNumber, 0, exitType));
            return true;
        }

        var totalProgressWorker = worker.Progress + progress;

        if (IsProgressSufficient(totalProgressWorker))
            return false;

        worker.AddLogExit(new LogExit(documentNumber, progress, exitType));

        return true;
    }

    private bool IsProgressSufficient(int totalProgressWorker)
        => totalProgressWorker < minProgress;

    private bool IsRuleSuccess(List<string> accessRules, string messageFormat)
        =>
            accessRules.Count == 1 && messageFormat == "Ingreso exitoso";


    private string FormatErrorMessages(List<string> rulesError)
        => rulesError
            .Aggregate((current, next) => $"{current}, {next}");
}