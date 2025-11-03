namespace CajeroAutomatico;

public class AtmMachine : IAtm
{
    private readonly CalculateBills _calculateBills;
    private readonly Stock _stock;

    public AtmMachine()
    {
        _calculateBills = new CalculateBills();
        _stock = new Stock(StockInitial());
    }

    public List<Money> Withdraw(int quantity)
    {
        if (quantity == 0)
            return [];

        var calculatedBills = _calculateBills.CalculateWithdraw(quantity, _stock.GetStock());

        foreach (var billDetail in calculatedBills)
        {
            var stockBill = _stock.GetQuantityMoney(billDetail);

            if (stockBill < billDetail.quantity)
                throw new InvalidOperationException("No hay suficiente cantidad de billetes");

            _stock.UpdateStock(billDetail);
        }

        return calculatedBills;
    }


    public List<Money> GetBalance()
    {
        return [];
    }

    private List<Money> StockInitial()
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
            // new Money(1, TipoMoney.bill, 500),
        ];
    }
}