namespace BuilderYFactory.Factory;

public class NotificadorPush : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"🔔 Enviando Push a {destinatario}: {mensaje}");
        // Lógica específica de notificación push
    }
}
