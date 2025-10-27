//builder

using BuilderYFactory.Builder;
using BuilderYFactory.Factory;

var usuario = new UsuarioBuilder()
    .ConNombre("Juan")
    .ConApellido("Perez")
    .ConEdad(25)
    .DePais("Colombia")
    .ConProfesion("Desarrollador")
    .ConEmail("")
    .Build();

Console.WriteLine(usuario);


Console.WriteLine("Hello, World!");


//factory
NotificadorFactory factory = new EmailFactory();
INotificador notificador = factory.CrearNotificador();
notificador.Enviar("Hola");

NotificadorFactory factory2 = new SMSFactory();
INotificador notificador2 = factory.CrearNotificador();
notificador2.Enviar("Hola");