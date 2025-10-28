namespace BuilderYFactory.Factory;

public enum TipoNotificador
{
    email,
    sms,
    push,
}
public class NotificadorFactory
{
    public static INotificador Crear(TipoNotificador tipo)
    {
        return tipo switch
        {
            TipoNotificador.email => new NotificadorEmail(),
            TipoNotificador.sms => new NotificadorSMS(),
            TipoNotificador.push => new NotificadorPush(),
            _ => throw new ArgumentException($"Tipo de notificador '{tipo}' no soportado")
        };
    }
}