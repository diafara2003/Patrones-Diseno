namespace ControlObra.Dominio;

public class ControlAccesoObra()
{
    public static string NoCumpleConLaReglaDeEspecialidad = "No cumple con la regla de especialidad";
    public static string NoCumpleConLaReglaDeCedula = "No cumple con la regla de cedula";
    public static string NoCumpleConLaReglaDelAvanceMinimo = "No cumple con la regla del avance minimo del 50%";
    public static string IngresoExitoso = "Ingreso exitoso";
    public static string NoCumpleConLaReglaDeCumpleaños = "No cumple con la regla de cumpleaños";


    private readonly List<Worker> _employs = [];

    private bool RuleForOnlyEmploysCategory(Worker employ) => employ.speciality == TypeSpecialty.Carpintero;

    private bool RuleForOnlyDocument(Worker employ) => int.Parse(employ.documentNumber) % 2 == 0;

    private bool RuleForOnlyEmployProgress(Worker employ) => employ.progress >= 50;

    private bool RuleForBirthDate(Worker employ) => employ.birthDate.Month == DateTime.Now.Month
                                                    && employ.birthDate.Day == DateTime.Now.Day;

    public string SignIn(Worker employ)
    {
        if (RuleForOnlyEmploysCategory(employ) is false)
            return NoCumpleConLaReglaDeEspecialidad;

        if (RuleForOnlyDocument(employ) is false)
            return NoCumpleConLaReglaDeCedula;

        if (RuleForOnlyEmployProgress(employ) is false)
            return NoCumpleConLaReglaDelAvanceMinimo;

        if (RuleForBirthDate(employ) is false)
            return NoCumpleConLaReglaDeCumpleaños;

        _employs.Add(employ);
        return IngresoExitoso;
    }
}