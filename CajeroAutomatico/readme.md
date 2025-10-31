## Iteración 1

### Reglas del negocio
- El objetivo es construir un cajero automático y nuestra primera tarea es crear el software que desglosará qué billetes y monedas debe recibir el cliente cuando intente hacer un retiro.

El contenido del cajero es:

| Valor | Tipo    |
|-------|---------|
| 500   | billete |
| 200   | billete |
| 100   | billete |
| 50    | billete |
| 20    | billete |
| 10    | billete |
| 5     | billete |
| 2     | modena  |
| 1     | moneda  |



## Iteración 2
### Reglas del negocio
- El cajero automático tiene la siguiente distribución de dinero.

- Cuando el cajero automático no disponga de dinero, debe devolver un error que indique: "El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano".
Si el cajero automático no tiene más billetes o monedas debe intentar utilizar otras cantidades para que el usuario pueda retirar el importe.


El estado inicial de cualquier cajero automático

| Valor | Tipo    | Número de unidades|
|-------|---------|-------------------|
| 500   | billete | 2                 |
| 200   | billete | 3                 |
| 100   | billete | 5                 |
| 50    | billete | 12                |
| 20    | billete | 20                |
| 10    | billete | 50                |
| 5     | billete | 100               |
| 2     | moneda  | 250               |
| 1     | moneda  | 500               |