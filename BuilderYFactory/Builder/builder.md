# Builder

#### El patrón Builder (constructor) es un patrón de diseño creacional que se usa para construir objetos complejos paso a paso.

#### En lugar de tener un constructor con mil parámetros o múltiples sobrecargas, el Builder permite crear objetos de manera más legible, controlada y flexible, usando una API fluida (fluent interface).

#### 🎯 Problema que resuelve

Imagina que tienes una clase Usuario con muchos parámetros opcionales:

``` c#
var usuario = new Usuario("Jhonnatan", "Ureña", 30, "Colombia", "Ingeniero", "jhonnatan@correo.com");

```

#### Aquí es donde entra el Factory Method.

```` c#
var usuario = new UsuarioBuilder()
    .ConNombre("Juan")
    .ConApellido("Perez")
    .ConEdad(25)
    .DePais("Colombia")
    .ConProfesion("Desarrollador")
    .ConEmail("")
    .Build();
````

#### 👉 qué pasa si no se asignan los campos obligatorios antes del Build().

#### una desventaja de los puntos débiles del patrón Builder si no se maneja bien

### 2 maneras de solucionarlo

#### Es un objeto valido

#### Una opcion es validar los campos antes de construir el objeto.

``` c#
public Usuario Build()
{
    if (string.IsNullOrWhiteSpace(_usuario.Nombre))
        throw new InvalidOperationException("El nombre es obligatorio.");

    if (string.IsNullOrWhiteSpace(_usuario.Pais))
        throw new InvalidOperationException("El país es obligatorio.");

    return _usuario;
}
```

