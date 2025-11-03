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

        resultado.Should().BeEquivalentTo(new List<Money> { new Money(500, TipoMoney.bill, 1) });
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
            new Money(500, TipoMoney.bill, 1),
            new Money(200, TipoMoney.bill, 1)
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
            new Money(500, TipoMoney.bill, 1),
            new Money(200, TipoMoney.bill, 1),
            new Money(100, TipoMoney.bill, 1)
        });
    }

    [Fact]
    public void Retirar_1725_RegresaCombinacionCorrecta()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        var resultado = cajero.Withdraw(1225);

        //Assert
        resultado.Should().BeEquivalentTo(new List<Money>
        {
            new Money(500, TipoMoney.bill, 2),
            new Money(200, TipoMoney.bill, 1),
            new Money(20, TipoMoney.bill, 1),
            new Money(5, TipoMoney.bill, 1),
        });
    }

    [Fact]
    public void Retirar_2000_SinSuficientesBilletes_DeberiaFallar()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        Action caller = () => cajero.Withdraw(2000);

        //Assert
        caller.Should().Throw<InvalidOperationException>().WithMessage("No hay suficiente cantidad de billetes");
    }

    [Fact]
    public void Retirar_MontoNoCombinableConStock_DeberiaLanzarExcepcion()
    {
        //Arrange
        var cajero = new AtmMachine();

        //Act
        Action caller = () => cajero.Withdraw(3);

        //Assert
        caller.Should().Throw<InvalidOperationException>().WithMessage("El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano");
    }
}