# 📝 TDD Test List

Esta lista guía el desarrollo paso a paso. En TDD, seleccionamos una prueba, la implementamos (Red -> Green), refactorizamos, y pasamos a la siguiente.

## Ciclo 1: Reglas de Ingreso
- [x] **Test 1**: Un trabajador puede ingresar si no hay reglas restrictivas configuradas.
- [x] **Test 2**: Configurar regla "Solo Carpinteros": Un 'Operario' NO puede ingresar.
- [x] **Test 3**: Configurar regla "Solo Carpinteros": Un 'Carpintero' SÍ puede ingresar.
- [x] **Test 4**: Configurar regla "Cédulas Pares": Cédula impar NO ingresa.
- [x] **Test 5**: Configurar regla "Cédulas Pares": Cédula par SÍ ingresa.
- [x] **Test 6**: Configurar regla "Avance Máximo 50%": Trabajador con 50% NO ingresa.
- [x] **Test 7**: Múltiples reglas: Debe cumplir TODAS (AND) para ingresar.

## Ciclo 2: Salida y Acumulación de Avance
- [x] **Test 8**: Salida por "Almuerzo" es siempre exitosa y no modifica el avance.
- [x] **Test 9**: Salida "Normal" con avance menor al mínimo (5%) es rechazada.
- [x] **Test 10**: Salida "Normal" con avance suficiente es exitosa y suma al acumulado.
- [x] **Test 11**: Verificar que el avance se acumula correctamente tras múltiples salidas.

## Ciclo 3: Bloqueo por Completitud
- [ ] **Test 12**: Si el avance acumulado llega al 100%, el trabajador queda en estado "Completado".
- [ ] **Test 13**: Un trabajador "Completado" NO puede volver a ingresar (ignora reglas del día).

## Ciclo 4: Reportes
- [ ] **Test 14**: Generar reporte de avance total por rol.
- [ ] **Test 15**: Identificar trabajador con más salidas.
- [ ] **Test 16**: Identificar trabajador con menor avance.
