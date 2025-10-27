# Patrones de Diseño en C#

Este proyecto es una implementación práctica de patrones de diseño creacionales en C# .NET 9.0, específicamente los patrones **Builder** y **Factory**.

## 📋 Descripción

El proyecto demuestra cómo utilizar dos de los patrones de diseño creacionales más importantes para resolver problemas comunes en el desarrollo de software:

- **Patrón Builder**: Construye objetos complejos paso a paso con una API fluida (fluent interface)
- **Patrón Factory**: Encapsula la lógica de creación de objetos, permitiendo crear instancias sin exponer la lógica de instanciación al cliente

## 🎯 Objetivo del Proyecto

Proporcionar ejemplos claros y prácticos de cómo implementar estos patrones de diseño en C#, mostrando:
- Cuándo usar cada patrón
- Qué problemas resuelven
- Ventajas y desventajas de cada uno
- Implementación práctica con código ejecutable

## 🚀 Requisitos Previos

- **.NET SDK 9.0** o superior
- Un IDE compatible (Visual Studio, Visual Studio Code, Rider, etc.)
- Conocimientos básicos de C# y programación orientada a objetos

## 📦 Instalación

1. Clonar el repositorio:
```bash
git clone https://github.com/diafara2003/Patrones-Diseno.git
cd Patrones-Diseno
```

2. Restaurar las dependencias:
```bash
cd BuilderYFactory
dotnet restore
```

3. Compilar el proyecto:
```bash
dotnet build
```

4. Ejecutar el proyecto:
```bash
dotnet run
```

## 🏗️ Estructura del Proyecto

```
Patrones-Diseno/
├── BuilderYFactory/
│   ├── Builder/
│   │   ├── Usuario.cs              # Clase Usuario (objeto a construir)
│   │   ├── UsuarioBuilder.cs       # Constructor del patrón Builder
│   │   └── builder.md              # Documentación del patrón Builder
│   ├── Factory/
│   │   ├── INotificador.cs         # Interfaz del producto
│   │   ├── NotificadorFactory.cs   # Clase Factory con método estático
│   │   ├── NotificadorEmail.cs     # Implementación concreta de Email
│   │   ├── NotificadorSMS.cs       # Implementación concreta de SMS
│   │   ├── NotificadorPush.cs      # Implementación concreta de Push
│   │   └── factory.md              # Documentación del patrón Factory
│   ├── Program.cs                  # Punto de entrada con ejemplos
│   └── BuilderYFactory.csproj      # Archivo de proyecto
└── README.md                       # Este archivo
```

## 🔨 Patrón Builder

### ¿Qué es?
El patrón Builder es un patrón creacional que se usa para construir objetos complejos paso a paso. En lugar de tener un constructor con múltiples parámetros, el Builder permite crear objetos de manera más legible y flexible.

### Problema que resuelve
Imagina que tienes una clase `Usuario` con muchos parámetros:
```csharp
var usuario = new Usuario("Jhonnatan", "Ureña", 30, "Colombia", "Ingeniero", "jhonnatan@correo.com");
```
Este código es difícil de leer y mantener.

### Solución con Builder
```csharp
var usuario = new UsuarioBuilder()
    .ConNombre("Juan")
    .ConApellido("Perez")
    .ConEdad(25)
    .DePais("Colombia")
    .ConProfesion("Desarrollador")
    .ConEmail("juan.perez@correo.com")
    .Build();
```

### Ventajas
- ✅ Código más legible y mantenible
- ✅ Permite construir objetos complejos paso a paso
- ✅ Facilita la validación de campos obligatorios
- ✅ Soporta diferentes representaciones del mismo objeto

### Implementación
La implementación incluye:
- **Usuario.cs**: Clase record con propiedades para el usuario
- **UsuarioBuilder.cs**: Clase builder con métodos fluidos para construir el usuario

## 🏭 Patrón Factory

### ¿Qué es?
El Factory es un patrón creacional que encapsula la lógica de creación de objetos. En lugar de usar `new` directamente, delegas la creación del objeto a una "fábrica" que sabe qué tipo crear.

### Problema que resuelve
Sin el patrón Factory, tendrías código con múltiples condicionales:
```csharp
if (tipo == "email")
    notificador = new NotificadorEmail();
else if (tipo == "sms")
    notificador = new NotificadorSMS();
else if (tipo == "push")
    notificador = new NotificadorPush();
```
❌ Problema: cada vez que agregues un nuevo tipo, debes modificar este código (viola el principio Open/Closed).

### Solución con Factory
```csharp
// El cliente solo conoce la interfaz INotificador
// No necesita saber qué clase concreta se está usando

INotificador notificador1 = NotificadorFactory.Crear("email");
notificador1.Enviar("Hola desde Factory!", "usuario@example.com");

INotificador notificador2 = NotificadorFactory.Crear("sms");
notificador2.Enviar("Código de verificación: 1234", "+521234567890");

INotificador notificador3 = NotificadorFactory.Crear("push");
notificador3.Enviar("Nueva actualización disponible", "device_token_123");
```

### Ventajas
- ✅ Encapsula la creación de objetos
- ✅ El cliente no necesita conocer las clases concretas
- ✅ Facilita agregar nuevos tipos de productos
- ✅ Centraliza la lógica de creación

### Implementación
La implementación incluye:
- **INotificador.cs**: Interfaz que define el contrato del producto
- **NotificadorFactory.cs**: Clase Factory con método estático `Crear()`
- **NotificadorEmail.cs**, **NotificadorSMS.cs** y **NotificadorPush.cs**: Implementaciones concretas

## 💻 Ejemplos de Uso

### Ejemplo completo del Builder
```csharp
using BuilderYFactory.Builder;

var usuario = new UsuarioBuilder()
    .ConNombre("Juan")
    .ConApellido("Perez")
    .ConEdad(25)
    .DePais("Colombia")
    .ConProfesion("Desarrollador")
    .ConEmail("juan.perez@ejemplo.com")
    .Build();

Console.WriteLine(usuario);
// Salida: Usuario { Nombre = Juan, Apellido = Perez, Edad = 25, Pais = Colombia, Profesion = Desarrollador, Email = juan.perez@ejemplo.com }
```

### Ejemplo completo del Factory
```csharp
using BuilderYFactory.Factory;

// El cliente solo conoce la interfaz INotificador
// No necesita saber qué clase concreta se está usando

INotificador notificador1 = NotificadorFactory.Crear("email");
notificador1.Enviar("Hola desde Factory!", "usuario@example.com");
// Salida: 📧 Enviando Email a usuario@example.com: Hola desde Factory!

INotificador notificador2 = NotificadorFactory.Crear("sms");
notificador2.Enviar("Código de verificación: 1234", "+521234567890");
// Salida: 📱 Enviando SMS a +521234567890: Código de verificación: 1234

INotificador notificador3 = NotificadorFactory.Crear("push");
notificador3.Enviar("Nueva actualización disponible", "device_token_123");
// Salida: 🔔 Enviando Push a device_token_123: Nueva actualización disponible
```

## 📚 Cuándo Usar Cada Patrón

### Usa Builder cuando:
- Tienes objetos con muchos parámetros opcionales
- Quieres que el código de construcción sea más legible
- Necesitas diferentes representaciones del mismo objeto
- Quieres validar el objeto antes de construirlo

### Usa Factory cuando:
- No quieres acoplar tu código a clases concretas
- Tienes lógica compleja para decidir qué tipo de objeto crear
- Planeas agregar más tipos de productos en el futuro
- Quieres centralizar la lógica de creación

## 🧪 Ejecución de Pruebas

Actualmente el proyecto es una aplicación de consola de demostración. Para verificar el funcionamiento:

```bash
cd BuilderYFactory
dotnet run
```

Deberías ver una salida similar a la siguiente:
```
Usuario { Nombre = Juan, Apellido = Perez, Edad = 25, Pais = Colombia, Profesion = Desarrollador, Email =  }
Hello, World!
📧 Enviando Email a usuario@example.com: Hola desde Factory!
📱 Enviando SMS a +521234567890: Código de verificación: 1234
🔔 Enviando Push a device_token_123: Nueva actualización disponible
```

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Para contribuir:

1. Haz fork del proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Haz commit de tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📖 Recursos Adicionales

Para más información sobre patrones de diseño:

- [Documentación del patrón Builder](./BuilderYFactory/Builder/builder.md)
- [Documentación del patrón Factory](./BuilderYFactory/Factory/factory.md)
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)
- [Microsoft Docs - Design Patterns](https://docs.microsoft.com/en-us/dotnet/architecture/modernize-with-azure-containers/modernize-existing-apps-to-cloud-optimized/what-about-cloud-optimized-applications)

## 📄 Licencia

Este proyecto es de código abierto y está disponible para fines educativos.

## ✍️ Autor

**diafara2003**

---

⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub!