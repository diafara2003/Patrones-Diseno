namespace BuilderYFactory.Factory;

public class NotificadorSMS : INotificador
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando mensaje por sms: {mensaje}");
    }
}