using FluentAssertions;

namespace CajeroAutomatico;

public class CajeroTest
{
    [Fact]
    public void Retirar_CantidadCero_RegresaListaVacia()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(0);

        //Assert
        resultado.Should().BeEmpty();
    }

    [Fact]
    public void Retirar500_Debe_RegresarUnBilleteDe500()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(500);

        //Assert

        resultado.Should().BeEquivalentTo(new List<int> { 500 });
    }
}