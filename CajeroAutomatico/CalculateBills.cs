namespace CajeroAutomatico;

public class CalculateBills
{
    private readonly List<Money> _currentMoney;

    public CalculateBills()
    {
        _currentMoney = InitialAmount();
    }

    public List<Money> CalculateWithdraw(int quantity)
    {
        var result = new List<Money>();

        foreach (var currentMoneyMachine in _currentMoney)
        {
            var quantityToWithdraw = QuantityToWithdraw(quantity, currentMoneyMachine);

            if (IsQuantityValidForWithdraw(quantityToWithdraw))
                continue;

            result.Add(currentMoneyMachine with { quantity = quantityToWithdraw });
            quantity -= CalculateRemainingQuantity(quantityToWithdraw, currentMoneyMachine);
        }

        return result;
    }

    private int CalculateRemainingQuantity(int quantityToWithdraw, Money currentMoneyMachine)
    {
        return quantityToWithdraw * currentMoneyMachine.value;
    }

    private bool IsQuantityValidForWithdraw(int quantityToWithdraw)
    {
        return quantityToWithdraw <= 0;
    }

    private int QuantityToWithdraw(int quantity, Money currentMoneyMachine)
    {
        return quantity / currentMoneyMachine.value;
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