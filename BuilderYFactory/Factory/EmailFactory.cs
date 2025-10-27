namespace BuilderYFactory.Factory;

public class EmailFactory : NotificadorFactory
{
    public override INotificador CrearNotificador()
        => new NotificadorEmail();
}