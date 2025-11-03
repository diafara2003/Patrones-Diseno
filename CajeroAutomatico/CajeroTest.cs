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

        resultado.Should().BeEquivalentTo(new List<Money> { new Money(500, TipoMoney.bill) });
    }

    [Fact]
    public void Retirar700_Debe_RegresarUnBilleteDe500YUnCoinDe200()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(700);

        //Assert

        resultado.Should().BeEquivalentTo(new List<Money>
        {
            new Money(500, TipoMoney.bill),
            new Money(200, TipoMoney.bill)
        });
    }

    [Fact]
    public void Retirar800_Debe_RegresarUnBilleteDe500YUnCoinDe200YUnCoinDe100()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(800);

        //Assert

        resultado.Should().BeEquivalentTo(new List<Money>
        {
            new Money(500, TipoMoney.bill),
            new Money(200, TipoMoney.bill),
            new Money(100, TipoMoney.bill)
        });
    }

    [Fact]
    public void Retirar_1725_RegresaCombinacionCorrecta()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(1725);

        //Assert
        resultado.Should().BeEquivalentTo(new List<Money>
        {
            new Money(500, TipoMoney.bill),
            new Money(500, TipoMoney.bill),
            new Money(200, TipoMoney.bill),
            new Money(200, TipoMoney.bill),
            new Money(300, TipoMoney.bill),
            new Money(100, TipoMoney.bill),
            new Money(20, TipoMoney.bill),
            new Money(5, TipoMoney.bill),
        });
    }
}