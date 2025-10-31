## Reglas
El universo de Game of Life es una cuadrícula ortogonal, bidimensional e infinita de células cuadradas, cada una de las cuales se encuentra en uno de los dos estados posibles: viva o muerta. Cada célula interactúa con sus ocho vecinas, que son las célula que están horizontal, vertical o diagonalmente adyacentes a ella. En cada paso del tiempo se producen las siguientes transiciones:

- Cualquier célula viva con menos de dos vecinas vivas muere, como si la causa fuera la infrapoblación.
- Cualquier célula viva con dos o tres vecinas vivas pasa a la siguiente generación.
- Cualquier célula viva con más de tres vecinas vivas muere, como por sobrepoblación.
- Cualquier célula muerta con exactamente tres vecinas vivas se convierte en una célula viva, como por reproducción.
- El patrón inicial constituye la semilla del sistema. La primera generación se crea aplicando las reglas mencionadas simultáneamente a cada célula de la semilla: los nacimientos y las muertes se producen simultáneamente, y el momento determinado en que esto ocurre se denomina tick (en pocas palabras, cada generación es una función pura de la anterior).

Tu juego debe ser construido con el estado inicial de una matriz bidimensional de valores booleanos y un único método público para pasar a la siguiente generación:

```c#
public class GameOfLife {
public GameOfLife(boolean[][] board);
public void nextGen();
}
```

## Observaciones

- Las dimensiones de la matriz permanecen constantes durante todo el juego: el "universo" nunca crece.
- Las células fuera de los límites de la matriz deben considerarse permanentemente muertas (nunca vuelven a la vida).