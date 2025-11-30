namespace ControlObra.Dominio;

public static class WorkerExtensions
{
    extension(List<LogExit> worker)
    {
        public int GetProgress() => worker
            .Where(log => log.exitType != ExitType.Lunch)
            .Sum(log => log.progress);
    }
}