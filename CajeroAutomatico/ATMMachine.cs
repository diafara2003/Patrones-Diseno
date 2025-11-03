namespace CajeroAutomatico;

public class AtmMachine : IAtm
{
    private readonly CalculateBills _calculateBills;

    public AtmMachine()
    {
        _calculateBills = new CalculateBills();
    }

    public List<Money> Withdraw(int quantity)
    {
        if (quantity == 0)
            return [];

        return _calculateBills.CalculateWithdraw(quantity);
    }


    public List<Money> GetBalance()
    {
        return [];
    }
}