namespace ControlObra.Dominio;

public class Worker(
    string name,
    string documentNumber,
    DateTime birthDate,
    TypeSpecialty speciality
)
{
    public string Name => name;

    public string DocumentNumber => documentNumber;
    public DateTime BirthDate => birthDate;
    public TypeSpecialty Speciality => speciality;
    private List<LogExit> _exitLogs = [];

    public int Progress => _exitLogs.GetProgress();


    public void AddLogExit(LogExit logExit) => _exitLogs.Add(logExit);
}