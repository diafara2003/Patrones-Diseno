namespace CajeroAutomatico;

public class CalculateBills
{
   

    public List<Money> CalculateWithdraw(int quantity, List<Money> stock)
    {
        var result = new List<Money>();

        foreach (var currentMoneyMachine in stock)
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

  
}