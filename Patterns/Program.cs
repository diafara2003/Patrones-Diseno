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
// El cliente solo conoce la interfaz INotificador
// No necesita saber qué clase concreta se está usando

INotificador notificador1 = NotificadorFactory.Crear(TipoNotificador.email);
notificador1.Enviar("Hola desde Factory!", "usuario@example.com");

INotificador notificador2 = NotificadorFactory.Crear(TipoNotificador.sms);
notificador2.Enviar("Código de verificación: 1234", "+521234567890");

INotificador notificador3 = NotificadorFactory.Crear(TipoNotificador.push);
notificador3.Enviar("Nueva actualización disponible", "device_token_123");