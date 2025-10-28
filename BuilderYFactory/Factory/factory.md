# Factory Method Pattern

## 📖 Definición

El **Factory Method** es un patrón creacional que define una interfaz para crear objetos, pero permite que las **subclases decidan qué clase concreta instanciar**.

#### 👉 En otras palabras:
En lugar de usar `new` directamente en tu código, delegas la creación del objeto a una "fábrica" que sabe qué tipo crear. Las subclases de la fábrica son las que realmente deciden qué clase concreta instanciar.

---

## 🎯 Problema que Resuelve

Supón que tienes un sistema de notificaciones que puede enviar mensajes por Email o SMS.

### ❌ Sin patrón Factory:

```csharp
// Código acoplado a clases concretas
INotificador notificador;

if (tipo == "email")
    notificador = new NotificadorEmail();
else if (tipo == "sms")
    notificador = new NotificadorSMS();

notificador.Enviar("Mensaje");
```

**Problemas:**
- Acoplamiento directo a clases concretas
- Difícil de mantener y extender
- Viola el principio Open/Closed

---

## 📐 Estructura del Patrón

```
┌─────────────────────────────┐
│  <<abstract>>               │
│  NotificadorFactory         │
├─────────────────────────────┤
│ + CrearNotificador()        │ ◄─── Factory Method
└──────────────▲──────────────┘
               │
               │ heredan
    ┏━━━━━━━━━━┻━━━━━━━━━━┓
    ┃                      ┃
┌───┴────────┐      ┌──────┴─────┐
│EmailFactory│      │ SMSFactory │
├────────────┤      ├────────────┤
│+ CrearNot..│      │+ CrearNot..│
└────┬───────┘      └─────┬──────┘
     │ crea              │ crea
     ▼                   ▼
┌─────────────┐     ┌─────────────┐
│Notificador  │     │Notificador  │
│   Email     │     │    SMS      │
└─────────────┘     └─────────────┘
     △                    △
     │                    │
     └──────────┬─────────┘
                │ implementan
    ┌───────────┴────────────┐
    │  <<interface>>          │
    │    INotificador         │
    ├─────────────────────────┤
    │ + Enviar(mensaje)       │
    └─────────────────────────┘
```

---

## 💻 Implementación Completa

### 1️⃣ Interfaz del Producto

```csharp
public interface INotificador
{
    void Enviar(string mensaje);
}
```

### 2️⃣ Productos Concretos

```csharp
public class NotificadorEmail : INotificador
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"📧 Enviando mensaje por email: {mensaje}");
        // Lógica específica de envío por email
    }
}

public class NotificadorSMS : INotificador
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"📱 Enviando mensaje por SMS: {mensaje}");
        // Lógica específica de envío por SMS
    }
}
```

### 3️⃣ Clase Factory Abstracta (Creator)

```csharp
public abstract class NotificadorFactory
{
    // Factory Method - método abstracto que las subclases implementarán
    public abstract INotificador CrearNotificador();

    // Método opcional que usa el Factory Method
    public void EnviarNotificacion(string mensaje)
    {
        INotificador notificador = CrearNotificador();
        notificador.Enviar(mensaje);
    }
}
```

### 4️⃣ Factories Concretas (Concrete Creators)

```csharp
public class EmailFactory : NotificadorFactory
{
    public override INotificador CrearNotificador()
    {
        return new NotificadorEmail();
    }
}

public class SMSFactory : NotificadorFactory
{
    public override INotificador CrearNotificador()
    {
        return new NotificadorSMS();
    }
}
```

### 5️⃣ Uso del Cliente

```csharp
class Program
{
    static void Main(string[] args)
    {
        // El cliente trabaja con la abstracción NotificadorFactory
        NotificadorFactory factory;

        // Decidir qué factory usar (puede basarse en configuración, user input, etc.)
        string tipoNotificacion = "email"; // O leer de configuración

        if (tipoNotificacion == "email")
            factory = new EmailFactory();
        else
            factory = new SMSFactory();

        // Usar la factory sin conocer la clase concreta
        INotificador notificador = factory.CrearNotificador();
        notificador.Enviar("Hola desde Factory Method!");

        // O usar el método helper
        factory.EnviarNotificacion("Mensaje usando método helper");
    }
}
```

**Salida:**
```
📧 Enviando mensaje por email: Hola desde Factory Method!
📧 Enviando mensaje por email: Mensaje usando método helper
```

---

## 🧠 ¿Qué Ganamos con Esto?

### ✅ Ventajas

1. **Desacoplamiento**: El código cliente no está acoplado a clases concretas
2. **Extensibilidad**: Fácil agregar nuevos tipos de notificadores sin modificar código existente
3. **Principio Open/Closed**: Abierto para extensión, cerrado para modificación
4. **Single Responsibility**: Cada factory se encarga de crear un solo tipo de producto
5. **Flexibilidad**: Las subclasses tienen control total sobre qué objeto crear

### ❌ Desventajas

1. **Complejidad**: Requiere crear una nueva clase factory por cada producto
2. **Más código**: Mayor cantidad de clases y archivos
3. **Overhead**: Puede ser excesivo para casos simples

---

## 🔧 Ejemplo de Extensión

Para agregar un nuevo tipo de notificador (ej: Push), solo necesitas:

### Paso 1: Crear el producto concreto
```csharp
public class NotificadorPush : INotificador
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"🔔 Enviando notificación push: {mensaje}");
    }
}
```

### Paso 2: Crear la factory concreta
```csharp
public class PushFactory : NotificadorFactory
{
    public override INotificador CrearNotificador()
    {
        return new NotificadorPush();
    }
}
```

### Paso 3: Usar la nueva factory
```csharp
NotificadorFactory factory = new PushFactory();
INotificador notificador = factory.CrearNotificador();
notificador.Enviar("Nueva notificación!");
// Salida: 🔔 Enviando notificación push: Nueva notificación!
```

**✨ No necesitaste modificar ninguna clase existente!**

---

## 📚 Cuándo Usar Factory Method

### ✅ Usa Factory Method cuando:

- No sabes de antemano los tipos exactos de objetos que tu código necesitará
- Quieres proporcionar a los usuarios una forma de extender componentes internos
- Deseas reutilizar objetos existentes en lugar de reconstruirlos (puede combinarse con pool)
- Quieres desacoplar el código cliente de las clases concretas
- Tienes una jerarquía de productos y una jerarquía paralela de creators

### ❌ No uses Factory Method cuando:

- Solo tienes un tipo de producto (usa instanciación directa)
- La lógica de creación es muy simple (puede ser overkill)
- No planeas extender con nuevos tipos (YAGNI - You Ain't Gonna Need It)

---

## 🆚 Factory Method vs Simple Factory vs Abstract Factory

| Característica | Factory Method | Simple Factory | Abstract Factory |
|---|---|---|---|
| **Patrón** | Patrón GoF oficial | Idiom común | Patrón GoF oficial |
| **Herencia** | ✅ Usa herencia | ❌ Usa composición | ✅ Usa herencia |
| **Flexibilidad** | Alta | Media | Muy alta |
| **Complejidad** | Media | Baja | Alta |
| **Uso típico** | Un tipo de producto | Un tipo de producto | Familias de productos relacionados |

---

## 💡 Tips y Mejores Prácticas

1. **Nombrado**: Usa nombres descriptivos como `EmailFactory`, no `Factory1`
2. **Método abstracto**: Puede ser `protected` si solo se usa internamente
3. **Parámetros**: El Factory Method puede recibir parámetros para customizar la creación
4. **Lazy Creation**: Puedes cachear las instancias creadas si son reutilizables
5. **Combinaciones**: Factory Method se combina bien con Singleton, Prototype, y Builder

---

## 🔗 Referencias

- **Design Patterns: Elements of Reusable Object-Oriented Software** (Gang of Four)
- **Head First Design Patterns**
- [Refactoring Guru - Factory Method](https://refactoring.guru/design-patterns/factory-method)