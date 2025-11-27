### 🏗️ Kata: Control de Accesos a Obra

En una obra de construcción, los trabajadores entran y salen varias veces al día. El objetivo de esta kata es construir un sistema que registre estos movimientos y permita consultar el estado actual de la obra y las horas trabajadas por cada persona.

La finalidad es practicar modelado orientado a objetos, validaciones del dominio y encapsulamiento adecuado, sin exponer estructuras internas.

### 🎯 Objetivo de la Kata

- Modelar un sistema que gestione:
  - Entradas y salidas de trabajadores.
  - Quién está actualmente dentro de la obra.
  - Cuánto tiempo trabajó cada trabajador en un día.

### El sistema debe permitir:

- Registrar la entrada de un trabajador.
- Registrar la salida de un trabajador.

### Cada registro incluye:

- trabajadorId
- hora (o fecha y hora, según diseño)

### 👉 Validaciones obligatorias

El sistema no debe permitir:

- ❌ Registrar una entrada si el trabajador ya está dentro.
- ❌ Registrar una salida si el trabajador no ha ingresado.
- ❌ Registrar dos entradas seguidas el mismo día.
- ❌ Tener una entrada sin su salida correspondiente.
- ❌ Cerrar el día con estados inconsistentes.

### 👉 Consultas

El sistema debe ofrecer:
- Lista de los trabajadores actualmente dentro de la obra.

- Horas trabajadas por cada trabajador ese día.

