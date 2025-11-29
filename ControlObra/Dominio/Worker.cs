namespace ControlObra.Dominio;

public class Worker
{
    public string Name => _name;

    public string DocumentNumber => _documentNumber;
    public DateTime BirthDate => _birthDate;
    public TypeSpecialty Speciality => _speciality;
    public int Progress => _exitLogs.GetProgress();
    private List<LogExit> _exitLogs = [];
    private readonly string _name;
    private readonly string _documentNumber;
    private readonly DateTime _birthDate;
    private readonly TypeSpecialty _speciality;

    public Worker(string name,
        string documentNumber,
        DateTime birthDate,
        TypeSpecialty speciality)
    {
        ArgumentException.ThrowIfNullOrEmpty(documentNumber);
        ArgumentException.ThrowIfNullOrEmpty(name);

        _name = name;
        _documentNumber = documentNumber;
        _birthDate = birthDate;
        _speciality = speciality;
    }

    public void AddLogExit(LogExit logExit)
        => _exitLogs.Add(logExit);
}