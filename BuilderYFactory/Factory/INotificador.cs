namespace BuilderYFactory.Factory;

public interface INotificador
{
    void Enviar(string mensaje, string destinatario);
}