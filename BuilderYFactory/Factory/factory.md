# Factory

#### patrón creacional, como Builder, pero con un propósito distinto:
en lugar de construir un objeto paso a paso, el Factory se enfoca en decidir qué tipo de objeto crear.

define una interfaz para crear objetos, pero permite que las subclases decidan cuál clase concreta la instancia.

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

#### 🧠 ¿Qué ganamos con esto?

- Encapsulas la creación de objetos.

- El cliente no necesita conocer las clases concretas.


#### Cuándo usar el patrón Factory

#### Usa un Factory cuando:

- No quieres acoplar tu código a clases concretas.

- Tienes lógica compleja para decidir qué tipo de objeto crear.

- Planeas agregar más tipos de productos en el futuro.