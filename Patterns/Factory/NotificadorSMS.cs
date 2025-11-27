namespace BuilderYFactory.Factory;

public class NotificadorSMS : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"📱 Enviando SMS a {destinatario}: {mensaje}");
        // Lógica específica de envío por SMS
    }
}