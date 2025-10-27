namespace BuilderYFactory.Factory;

public class NotificadorEmail : INotificador
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando mensaje por email: {mensaje}");
    }
}