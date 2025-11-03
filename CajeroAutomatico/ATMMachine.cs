namespace CajeroAutomatico;

public class AtmMachine : IAtm
{
    private readonly CalculateBills _calculateBills;
    private readonly List<Money> _stock;

    public AtmMachine()
    {
        _calculateBills = new CalculateBills();
        _stock = StockInitial();
    }

    public List<Money> Withdraw(int quantity)
    {
        if (quantity == 0)
            return [];

        var calculatedBills = _calculateBills.CalculateWithdraw(quantity, _stock);

        foreach (var billDetail in calculatedBills)
        {
            var stockBill = RetrieveBillCount(billDetail);

            if (stockBill < billDetail.quantity)
                throw new InvalidOperationException("No hay suficiente cantidad de billetes");

            UpdateStock(billDetail);
        }

        return calculatedBills;
    }

    private void UpdateStock(Money money)
    {
        var indexMoney = _stock.FindIndex(c => c.value == money.value && c.typeMoney == money.typeMoney);

        if (indexMoney == -1)
            return;

        var remainingQuantity = _stock[indexMoney].quantity - money.quantity;
        _stock[indexMoney] = money with { quantity = remainingQuantity };
    }

    private int RetrieveBillCount(Money ammount)
    {
        return _stock.Find(c => c.value == ammount.value && c.typeMoney == ammount.typeMoney)?.quantity ??
               0;
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
            new Money(1, TipoMoney.bill, 500),
        ];
    }
}