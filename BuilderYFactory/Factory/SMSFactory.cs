namespace BuilderYFactory.Factory;

public class SMSFactory : NotificadorFactory
{
    public override INotificador CrearNotificador()
    {
        return new NotificadorSMS();
    }
}