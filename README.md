# Patrones de Diseño en Software

## 📋 Índice
- [Introducción](#introducción)
- [Patrones Creacionales](#patrones-creacionales)
- [Patrones Estructurales](#patrones-estructurales)
- [Patrones Comportamentales](#patrones-comportamentales)
- [Mejores Prácticas](#mejores-prácticas)

## Introducción

Los **patrones de diseño** son soluciones reutilizables a problemas comunes que surgen en el desarrollo de software. Fueron popularizados por el libro "Design Patterns: Elements of Reusable Object-Oriented Software" (conocido como el libro de la "Gang of Four" o GoF).

### ¿Por qué usar patrones de diseño?

- **Reutilización**: Soluciones probadas que ahorran tiempo
- **Comunicación**: Vocabulario común entre desarrolladores
- **Mantenibilidad**: Código más organizado y fácil de mantener
- **Escalabilidad**: Facilitan el crecimiento del sistema

---

## Patrones Creacionales

Los patrones creacionales se enfocan en la creación de objetos, proporcionando mecanismos que aumentan la flexibilidad y reutilización del código.

### 1. Singleton

**Propósito**: Garantizar que una clase tenga una única instancia y proporcionar un punto de acceso global a ella.

**Cuándo usar**:
- Cuando necesitas exactamente una instancia de una clase (ej: configuración, conexión a BD)
- Cuando la instancia debe ser accesible desde cualquier punto del código

**Ejemplo conceptual**:
```python
class Singleton:
    _instance = None
    
    def __new__(cls):
        if cls._instance is None:
            cls._instance = super().__new__(cls)
        return cls._instance
```

**Ventajas**: Control sobre la creación de instancias, ahorro de memoria
**Desventajas**: Puede dificultar las pruebas unitarias, viola el principio de responsabilidad única

---

### 2. Factory Method (Método Fábrica)

**Propósito**: Define una interfaz para crear objetos, pero permite a las subclases decidir qué clase instanciar.

**Cuándo usar**:
- Cuando no conoces de antemano los tipos exactos de objetos que necesitas crear
- Cuando quieres proporcionar una forma de extender las partes internas de tu biblioteca

**Ejemplo conceptual**:
```python
class Creator:
    def factory_method(self):
        pass
    
    def operation(self):
        product = self.factory_method()
        return product.operation()

class ConcreteCreatorA(Creator):
    def factory_method(self):
        return ConcreteProductA()
```

**Ventajas**: Desacopla el código de creación del código de uso
**Desventajas**: Puede aumentar la complejidad del código

---

### 3. Abstract Factory (Fábrica Abstracta)

**Propósito**: Proporciona una interfaz para crear familias de objetos relacionados sin especificar sus clases concretas.

**Cuándo usar**:
- Cuando el sistema debe ser independiente de cómo se crean sus productos
- Cuando necesitas trabajar con múltiples familias de productos relacionados

**Ventajas**: Aísla clases concretas, facilita el intercambio de familias de productos
**Desventajas**: Agregar nuevos productos puede ser complicado

---

### 4. Builder (Constructor)

**Propósito**: Separa la construcción de un objeto complejo de su representación, permitiendo crear diferentes representaciones usando el mismo proceso de construcción.

**Cuándo usar**:
- Cuando el algoritmo de creación de un objeto complejo debe ser independiente de las partes que lo componen
- Cuando el proceso de construcción debe permitir diferentes representaciones

**Ejemplo conceptual**:
```python
class Builder:
    def build_part_a(self): pass
    def build_part_b(self): pass
    def get_result(self): pass

class Director:
    def construct(self, builder):
        builder.build_part_a()
        builder.build_part_b()
        return builder.get_result()
```

**Ventajas**: Control fino sobre el proceso de construcción, permite construir objetos paso a paso
**Desventajas**: Aumenta la complejidad general del código

---

### 5. Prototype (Prototipo)

**Propósito**: Permite copiar objetos existentes sin que el código dependa de sus clases.

**Cuándo usar**:
- Cuando las clases a instanciar se especifican en tiempo de ejecución
- Cuando la creación de un objeto es costosa

**Ventajas**: Reduce el número de subclases, oculta las clases concretas
**Desventajas**: Clonar objetos complejos con referencias circulares puede ser complicado

---

## Patrones Estructurales

Los patrones estructurales se ocupan de cómo las clases y objetos se componen para formar estructuras más grandes.

### 1. Adapter (Adaptador)

**Propósito**: Permite que interfaces incompatibles trabajen juntas, actuando como un puente entre dos interfaces.

**Cuándo usar**:
- Cuando quieres usar una clase existente pero su interfaz no coincide con la que necesitas
- Cuando quieres crear una clase reutilizable que coopere con clases no relacionadas

**Ejemplo conceptual**:
```python
class Target:
    def request(self): pass

class Adapter(Target):
    def __init__(self, adaptee):
        self.adaptee = adaptee
    
    def request(self):
        return self.adaptee.specific_request()
```

**Ventajas**: Reutiliza código existente, desacopla el cliente de las clases adaptadas
**Desventajas**: Aumenta la complejidad general del código

---

### 2. Bridge (Puente)

**Propósito**: Separa una abstracción de su implementación, permitiendo que ambas varíen independientemente.

**Cuándo usar**:
- Cuando quieres evitar un enlace permanente entre abstracción e implementación
- Cuando tanto las abstracciones como las implementaciones deben ser extensibles mediante subclases

**Ventajas**: Desacopla interfaz de implementación, mejora la extensibilidad
**Desventajas**: Aumenta la complejidad del diseño

---

### 3. Composite (Compuesto)

**Propósito**: Compone objetos en estructuras de árbol para representar jerarquías parte-todo, permitiendo tratar objetos individuales y composiciones de manera uniforme.

**Cuándo usar**:
- Cuando quieres representar jerarquías de objetos parte-todo
- Cuando quieres que los clientes ignoren la diferencia entre composiciones de objetos y objetos individuales

**Ejemplo conceptual**:
```python
class Component:
    def operation(self): pass

class Composite(Component):
    def __init__(self):
        self.children = []
    
    def add(self, component):
        self.children.append(component)
    
    def operation(self):
        for child in self.children:
            child.operation()
```

**Ventajas**: Facilita agregar nuevos tipos de componentes, simplifica el código del cliente
**Desventajas**: Puede hacer el diseño demasiado general

---

### 4. Decorator (Decorador)

**Propósito**: Añade responsabilidades adicionales a un objeto dinámicamente, proporcionando una alternativa flexible a la herencia.

**Cuándo usar**:
- Cuando necesitas añadir responsabilidades a objetos de forma dinámica y transparente
- Cuando la extensión mediante herencia no es práctica

**Ventajas**: Más flexible que la herencia, evita clases con muchas características
**Desventajas**: Muchos objetos pequeños pueden complicar el diseño

---

### 5. Facade (Fachada)

**Propósito**: Proporciona una interfaz unificada y simplificada a un conjunto de interfaces en un subsistema.

**Cuándo usar**:
- Cuando quieres proporcionar una interfaz simple a un subsistema complejo
- Cuando hay muchas dependencias entre clientes y clases de implementación

**Ventajas**: Simplifica el uso de subsistemas complejos, reduce el acoplamiento
**Desventajas**: Puede convertirse en un objeto todopoderoso

---

### 6. Flyweight (Peso Ligero)

**Propósito**: Usa compartición para soportar eficientemente grandes cantidades de objetos de grano fino.

**Cuándo usar**:
- Cuando la aplicación usa un gran número de objetos
- Cuando los costos de almacenamiento son altos debido a la cantidad de objetos

**Ventajas**: Reduce el uso de memoria cuando hay muchos objetos similares
**Desventajas**: Aumenta la complejidad, puede sacrificar velocidad por memoria

---

### 7. Proxy (Apoderado)

**Propósito**: Proporciona un sustituto o marcador de posición para otro objeto para controlar el acceso a él.

**Cuándo usar**:
- Cuando necesitas una referencia más versátil a un objeto que un simple puntero
- Proxy remoto, virtual, de protección o de copia en escritura

**Ventajas**: Control sobre el objeto, puede optimizar el uso de recursos
**Desventajas**: Puede ralentizar el tiempo de respuesta

---

## Patrones Comportamentales

Los patrones comportamentales se ocupan de la comunicación entre objetos y la asignación de responsabilidades.

### 1. Chain of Responsibility (Cadena de Responsabilidad)

**Propósito**: Evita acoplar el emisor de una petición a su receptor, dando a más de un objeto la posibilidad de responder a la petición.

**Cuándo usar**:
- Cuando más de un objeto puede manejar una petición y el manejador no se conoce de antemano
- Cuando quieres emitir una petición a uno de varios objetos sin especificar explícitamente el receptor

**Ventajas**: Reduce el acoplamiento, añade flexibilidad al asignar responsabilidades
**Desventajas**: No se garantiza que la petición sea recibida

---

### 2. Command (Comando)

**Propósito**: Encapsula una petición como un objeto, permitiendo parametrizar clientes con diferentes peticiones, encolar peticiones y soportar operaciones deshacer.

**Cuándo usar**:
- Cuando quieres parametrizar objetos con acciones a realizar
- Cuando quieres especificar, encolar y ejecutar peticiones en diferentes momentos
- Cuando necesitas soporte para deshacer operaciones

**Ejemplo conceptual**:
```python
class Command:
    def execute(self): pass
    def undo(self): pass

class ConcreteCommand(Command):
    def __init__(self, receiver):
        self.receiver = receiver
    
    def execute(self):
        self.receiver.action()
```

**Ventajas**: Desacopla el objeto que invoca la operación del que sabe cómo realizarla
**Desventajas**: Puede resultar en muchas clases de comandos pequeños

---

### 3. Iterator (Iterador)

**Propósito**: Proporciona una forma de acceder secuencialmente a los elementos de un objeto agregado sin exponer su representación subyacente.

**Cuándo usar**:
- Cuando necesitas acceder al contenido de un objeto agregado sin exponer su representación interna
- Cuando quieres soportar múltiples recorridos de objetos agregados

**Ventajas**: Simplifica la interfaz del agregado, soporta múltiples recorridos
**Desventajas**: Puede ser excesivo para colecciones simples

---

### 4. Mediator (Mediador)

**Propósito**: Define un objeto que encapsula cómo interactúan un conjunto de objetos, promoviendo el bajo acoplamiento.

**Cuándo usar**:
- Cuando un conjunto de objetos se comunica de formas bien definidas pero complejas
- Cuando reutilizar un objeto es difícil porque se refiere y comunica con muchos otros objetos

**Ventajas**: Reduce las dependencias entre objetos, centraliza el control
**Desventajas**: El mediador puede convertirse en un objeto muy complejo

---

### 5. Memento (Recuerdo)

**Propósito**: Sin violar la encapsulación, captura y externaliza el estado interno de un objeto para que pueda ser restaurado posteriormente.

**Cuándo usar**:
- Cuando necesitas guardar instantáneas del estado de un objeto
- Cuando una interfaz directa para obtener el estado expondría detalles de implementación

**Ventajas**: Preserva los límites de encapsulación, simplifica el originador
**Desventajas**: Puede ser costoso en memoria

---

### 6. Observer (Observador)

**Propósito**: Define una dependencia uno-a-muchos entre objetos, de manera que cuando un objeto cambia su estado, todos sus dependientes son notificados automáticamente.

**Cuándo usar**:
- Cuando un cambio en un objeto requiere cambiar otros, y no sabes cuántos objetos necesitan cambiar
- Cuando un objeto debe notificar a otros sin asumir quiénes son esos objetos

**Ejemplo conceptual**:
```python
class Subject:
    def __init__(self):
        self.observers = []
    
    def attach(self, observer):
        self.observers.append(observer)
    
    def notify(self):
        for observer in self.observers:
            observer.update()
```

**Ventajas**: Acoplamiento abstracto entre sujeto y observador, soporte para broadcast
**Desventajas**: Actualizaciones inesperadas, puede haber problemas de rendimiento

---

### 7. State (Estado)

**Propósito**: Permite a un objeto alterar su comportamiento cuando su estado interno cambia, pareciendo que el objeto cambia de clase.

**Cuándo usar**:
- Cuando el comportamiento de un objeto depende de su estado
- Cuando las operaciones tienen condicionales grandes que dependen del estado del objeto

**Ventajas**: Localiza el comportamiento específico de cada estado, hace explícitas las transiciones de estado
**Desventajas**: Aumenta el número de clases

---

### 8. Strategy (Estrategia)

**Propósito**: Define una familia de algoritmos, encapsula cada uno, y los hace intercambiables. Permite que el algoritmo varíe independientemente de los clientes que lo usan.

**Cuándo usar**:
- Cuando muchas clases relacionadas difieren solo en su comportamiento
- Cuando necesitas diferentes variantes de un algoritmo
- Cuando un algoritmo usa datos que los clientes no deberían conocer

**Ejemplo conceptual**:
```python
class Strategy:
    def algorithm(self): pass

class Context:
    def __init__(self, strategy):
        self.strategy = strategy
    
    def execute_strategy(self):
        return self.strategy.algorithm()
```

**Ventajas**: Familias de algoritmos relacionados, alternativa a la herencia
**Desventajas**: Los clientes deben conocer las diferentes estrategias

---

### 9. Template Method (Método Plantilla)

**Propósito**: Define el esqueleto de un algoritmo en una operación, posponiendo algunos pasos a las subclases.

**Cuándo usar**:
- Cuando quieres que las subclases implementen pasos específicos de un algoritmo
- Cuando quieres controlar las extensiones de las subclases

**Ventajas**: Reutiliza código, control sobre las extensiones de las subclases
**Desventajas**: Puede violar el principio de sustitución de Liskov

---

### 10. Visitor (Visitante)

**Propósito**: Representa una operación a realizar sobre elementos de una estructura de objetos, permitiendo definir nuevas operaciones sin cambiar las clases de los elementos.

**Cuándo usar**:
- Cuando necesitas realizar operaciones sobre objetos en una estructura compleja
- Cuando quieres agregar nuevas operaciones sin cambiar las clases de los elementos

**Ventajas**: Facilita agregar nuevas operaciones, agrupa operaciones relacionadas
**Desventajas**: Agregar nuevas clases de elementos es difícil

---

## Mejores Prácticas

### Principios SOLID

Los patrones de diseño suelen seguir los principios SOLID:

1. **S**ingle Responsibility (Responsabilidad Única): Una clase debe tener una sola razón para cambiar
2. **O**pen/Closed (Abierto/Cerrado): Abierto para extensión, cerrado para modificación
3. **L**iskov Substitution (Sustitución de Liskov): Los objetos derivados deben ser sustituibles por sus objetos base
4. **I**nterface Segregation (Segregación de Interfaces): Muchas interfaces específicas son mejores que una general
5. **D**ependency Inversion (Inversión de Dependencias): Depender de abstracciones, no de concreciones

### Consejos Generales

- ✅ **No uses patrones por usar**: Aplícalos solo cuando resuelvan un problema real
- ✅ **Mantén la simplicidad**: No sobre-ingenierices la solución
- ✅ **Conoce el problema primero**: Entiende bien el problema antes de aplicar un patrón
- ✅ **Combina patrones**: Muchas soluciones usan múltiples patrones trabajando juntos
- ✅ **Refactoriza hacia patrones**: A menudo es mejor refactorizar hacia un patrón cuando lo necesites
- ⚠️ **Evita el uso excesivo**: Demasiados patrones pueden hacer el código innecesariamente complejo

### Recursos Adicionales

- **Libro**: "Design Patterns: Elements of Reusable Object-Oriented Software" - Gang of Four
- **Libro**: "Head First Design Patterns" - Eric Freeman
- **Web**: [Refactoring.Guru](https://refactoring.guru/design-patterns) - Excelente recurso con ejemplos
- **Web**: [SourceMaking](https://sourcemaking.com/design_patterns) - Patrones con diagramas UML

---

## Contribuciones

Las contribuciones son bienvenidas. Si deseas agregar ejemplos de código, casos de uso adicionales o correcciones, por favor abre un pull request.

## Licencia

Este documento es de uso libre para fines educativos.

---

**Última actualización**: Octubre 2025