namespace CajeroAutomatico;

public class AtmMachine : IAtm
{
    private readonly List<Money> _currentMoney;

    public AtmMachine()
    {
        _currentMoney = InitialAmount();
    }

    public List<Money> Withdraw(int quantity)
    {
        return [];
    }

    public List<Money> GetBalance()
    {
        return [];
    }

    private List<Money> InitialAmount()
    {
        return
        [
            new Money(500, TipoMoney.bill, 2),
            new Money(200, TipoMoney.bill, 3),
            new Money(100, TipoMoney.bill, 5),
            new Money(50, TipoMoney.bill, 12),
            new Money(20, TipoMoney.bill, 20),
            new Money(10, TipoMoney.bill, 50),
            new Money(5, TipoMoney.bill, 100),
            new Money(2, TipoMoney.coin, 250),
            new Money(1, TipoMoney.bill, 500),
        ];
    }
}