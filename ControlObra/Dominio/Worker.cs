namespace ControlObra.Dominio;

public record Worker(
    string name,
    string lastName,
    string documentNumber,
    DateTime birthDate,
    TypeSpecialty speciality,
    int progress);

public record LogExit(string documentNumber,int progress, ExitType exitType);