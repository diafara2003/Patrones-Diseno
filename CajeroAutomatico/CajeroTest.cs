using FluentAssertions;

namespace CajeroAutomatico;

public class CajeroTest
{
    [Fact]
    public void Retirar_CantidadCero_RegresaListaVacia()
    {
        //Arrange
        var cajero = new ATMMachine();

        //Act
        var resultado = cajero.Withdraw(0);

        //Assert
        resultado.Should().BeEmpty();
    }
}