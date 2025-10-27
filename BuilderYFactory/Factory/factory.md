# Factory

#### patrón creacional, como Builder, pero con un propósito distinto:
- en lugar de construir un objeto paso a paso, el Factory se enfoca en decidir qué tipo de objeto crear.

- define una interfaz para crear objetos, pero permite que las subclases decidan cuál clase concreta la instancia.

#### 👉 En otras palabras:
en lugar de usar new directamente, delegas la creación del objeto a una “fábrica” que sabe qué tipo crear.

#### 🎯 Problema que resuelve

Supón que tienes un sistema de notificaciones que puede enviar mensajes por Email, SMS o Push.

Sin patrón Factory, harías algo así:

``` c#

if (tipo == "email")
    notificador = new NotificadorEmail();
else if (tipo == "sms")
    notificador = new NotificadorSMS();
else
    notificador = new NotificadorPush();
```

❌ Problema: cada vez que agregues un nuevo tipo, debes modificar este código (viola el principio Open/Closed).

---


## 💻 Implementación completa

### 1️⃣ Interfaz del Producto

``` c#
public interface INotificador
{
    void Enviar(string mensaje, string destinatario);
}
```

### 2️⃣ Productos Concretos

``` c#
public class NotificadorEmail : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"📧 Enviando Email a {destinatario}: {mensaje}");
        // Lógica específica de envío por email
    }
}

public class NotificadorSMS : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"📱 Enviando SMS a {destinatario}: {mensaje}");
        // Lógica específica de envío por SMS
    }
}

public class NotificadorPush : INotificador
{
    public void Enviar(string mensaje, string destinatario)
    {
        Console.WriteLine($"🔔 Enviando Push a {destinatario}: {mensaje}");
        // Lógica específica de notificación push
    }
}
```

### 3️⃣ La Fábrica

``` c#
public class NotificadorFactory
{
    public static INotificador Crear(string tipo)
    {
        return tipo.ToLower() switch
        {
            "email" => new NotificadorEmail(),
            "sms" => new NotificadorSMS(),
            "push" => new NotificadorPush(),
            _ => throw new ArgumentException($"Tipo de notificador '{tipo}' no soportado")
        };
    }
}
```

### 4️⃣ Uso del Cliente

``` c#
class Program
{
    static void Main(string[] args)
    {
        // El cliente solo conoce la interfaz INotificador
        // No necesita saber qué clase concreta se está usando

        INotificador notificador1 = NotificadorFactory.Crear("email");
        notificador1.Enviar("Hola desde Factory!", "usuario@example.com");

        INotificador notificador2 = NotificadorFactory.Crear("sms");
        notificador2.Enviar("Código de verificación: 1234", "+521234567890");

        INotificador notificador3 = NotificadorFactory.Crear("push");
        notificador3.Enviar("Nueva actualización disponible", "device_token_123");
    }
}
```

**Salida:**
```
📧 Enviando Email a usuario@example.com: Hola desde Factory!
📱 Enviando SMS a +521234567890: Código de verificación: 1234
🔔 Enviando Push a device_token_123: Nueva actualización disponible
```

---

#### 🧠 ¿Qué ganamos con esto?

- Encapsular la creación de objetos.

- El cliente no necesita conocer las clases concretas.


#### Usa un Factory cuando:

- No quieres acoplar tu código a clases concretas.

- Tienes lógica compleja para decidir qué tipo de objeto crear.

- Agregar más tipos de productos en el futuro.