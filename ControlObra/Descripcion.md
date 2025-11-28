## 📘 Descripción del Problema

En una obra de construcción, la empresa busca mantener un control riguroso sobre los movimientos del personal.
Aunque los trabajadores pueden ingresar y salir varias veces durante la jornada laboral, cada desplazamiento debe registrarse y cumplir con las normas operativas y de seguridad.

El sistema debe ser flexible, ya que **las reglas de ingreso cambian cada día**.

### 🔐 Reglas de Ingreso (Configurables)

Cada jornada se define un conjunto de reglas activas. El sistema debe permitir configurar cuáles de las siguientes reglas aplican para el día:

- **Restricción por Rol**: Solo se permite el ingreso a ciertos roles (ej. solo Carpinteros, o Carpinteros y Operarios).
- **Restricción por Cédula**: Solo pueden ingresar quienes tienen cédulas con cierta terminación (ej. terminadas en número par).
- **Restricción por Avance**: Solo empleados con un avance acumulado menor a cierto porcentaje (ej. 50%).

El sistema debe validar que el trabajador cumpla **todas** las reglas activas para permitir su ingreso.

### � Reglas de Salida

Cuando un trabajador intenta salir, debe indicar el motivo. El sistema valida la salida así:

1. **Salida por Almuerzo**: Siempre permitida. No requiere registrar avance.
2. **Salida Normal**:
   - El trabajador debe reportar el avance realizado en esa sesión.
   - Si el avance reportado es **inferior al mínimo requerido** (parametrable, ej. 5%), la salida es rechazada y debe volver a trabajar.
   - Si es aceptada, el avance se suma al acumulado del trabajador.

### ⛔ Bloqueo por Avance Completo

Cuando un trabajador alcanza el **100% de avance acumulado**, queda automáticamente bloqueado y **no puede volver a ingresar** a la obra, independientemente de las reglas del día.

### 🔢 Contador de Salidas

El sistema debe mantener un **contador de salidas válidas** por cada trabajador.

### 📊 Reporte Diario

Al finalizar la jornada, se debe generar un reporte con:

- **Avance diario por categoría**: Suma del avance logrado por todos los trabajadores de cada rol.
- **Trabajador con más salidas**: Nombre del trabajador que más veces salió.
- **Trabajador con menor avance**: Nombre del trabajador con el menor avance acumulado en el día.