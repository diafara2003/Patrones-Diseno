namespace ControlObra.Dominio;

public class Worker
{
    public string Name { get; }

    public string DocumentNumber { get; }

    public DateTime BirthDate { get; }

    public TypeSpecialty Speciality { get; }

    public int Progress => _exitLogs.GetProgress();
    public int CountExit => _exitLogs.Count;

    private readonly List<LogExit> _exitLogs = [];

    public Worker(string name,
        string documentNumber,
        DateTime birthDate,
        TypeSpecialty speciality)
    {
        ArgumentException.ThrowIfNullOrEmpty(documentNumber);
        ArgumentException.ThrowIfNullOrEmpty(name);


        Name = name;
        DocumentNumber = documentNumber;
        BirthDate = birthDate;
        Speciality = speciality;
    }

    public void AddLogExit(LogExit logExit)
        => _exitLogs.Add(logExit);
}