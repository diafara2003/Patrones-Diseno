namespace ControlObra.Dominio.Rules;

public class RuleForBirthDate : IAccessRule
{
   
    public string EvaluateRule(Worker worker)
    {
        var isAccess = worker.birthDate.Month == DateTime.Now.Month
                       && worker.birthDate.Day == DateTime.Now.Day;

        return isAccess is false ? "No cumple con la regla de cumpleaños" : string.Empty;
    }
}