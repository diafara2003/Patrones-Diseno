namespace CajeroAutomatico;

public class AtmMachine : IAtm
{
    private readonly List<MoneyMachine> _currentMoney;

    public AtmMachine()
    {
        _currentMoney = InitialAmount();
    }

    public List<Money> Withdraw(int quantity)
    {
        var result = new List<Money>();

        if (quantity == 0)
            return [];

        foreach (var currentMoneyMachine in _currentMoney)
        {
            var quantityToWithdraw = QuantityToWithdraw(quantity, currentMoneyMachine);

            if (IsQuantityValidForWithdraw(quantityToWithdraw))
                continue;

            result.Add(currentMoneyMachine.money);
            quantity -= CalculateRemainingQuantity(quantityToWithdraw, currentMoneyMachine);
        }

        return result;
    }

    private static int CalculateRemainingQuantity(int quantityToWithdraw, MoneyMachine currentMoneyMachine)
    {
        return quantityToWithdraw * currentMoneyMachine.money.value;
    }

    private static bool IsQuantityValidForWithdraw(int quantityToWithdraw)
    {
        return quantityToWithdraw <= 0;
    }

    private static int QuantityToWithdraw(int quantity, MoneyMachine currentMoneyMachine)
    {
        return quantity / currentMoneyMachine.money.value;
    }

    public List<Money> GetBalance()
    {
        return [];
    }

    private List<MoneyMachine> InitialAmount()
    {
        return
        [
            new MoneyMachine(new Money(500, TipoMoney.bill), 2),
            new MoneyMachine(new Money(200, TipoMoney.bill), 3),
            new MoneyMachine(new Money(100, TipoMoney.bill), 5),
            new MoneyMachine(new Money(50, TipoMoney.bill), 12),
            new MoneyMachine(new Money(20, TipoMoney.bill), 20),
            new MoneyMachine(new Money(10, TipoMoney.bill), 50),
            new MoneyMachine(new Money(5, TipoMoney.bill), 100),
            new MoneyMachine(new Money(2, TipoMoney.coin), 250),
            new MoneyMachine(new Money(1, TipoMoney.bill), 500),
        ];
    }
}