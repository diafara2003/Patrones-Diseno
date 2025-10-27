namespace BuilderYFactory.Factory;

public class NotificadorEmail : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"📧 Enviando Email a {destinatario}: {mensaje}");
        // Lógica específica de envío por email
    }
}