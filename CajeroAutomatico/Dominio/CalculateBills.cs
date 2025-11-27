namespace CajeroAutomatico;

public class CalculateBills
{
    public List<Money> CalculateWithdraw(int quantity, List<Money> stock)
    {
        var result = new List<Money>();

        var stockOrder = stock
            .Where(money => money.quantity > 0)
            .OrderByDescending(money => money.value)
            .ToList();


        foreach (var currentMoneyMachine in stockOrder)
        {
            var quantityToWithdraw = QuantityToWithdraw(quantity, currentMoneyMachine);

            if (IsQuantityValidForWithdraw(quantityToWithdraw))
                continue;

            result.Add(currentMoneyMachine with { quantity = quantityToWithdraw });
            quantity -= CalculateRemainingQuantity(quantityToWithdraw, currentMoneyMachine);
        }

        if (quantity > 0)
            throw new InvalidOperationException(
                "El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano");

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
}