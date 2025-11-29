namespace ControlObra.Dominio;

public static class WorkerExtensions
{
    public static int GetProgress(this List<LogExit> worker) => worker
        .Where(log => log.exitType != ExitType.Lunch)
        .Sum(log => log.progress);
}