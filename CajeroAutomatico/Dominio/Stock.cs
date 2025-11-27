namespace CajeroAutomatico;

public class Stock(List<Money> stock)
{
    private readonly List<Money> _stock = stock;

    public List<Money> GetStock() => _stock;

    public int GetQuantityMoney(Money money) =>
        _stock.Find(c => c.value == money.value && c.typeMoney == money.typeMoney)?.quantity
        ?? 0;

    public void UpdateStock(Money money)
    {
        var indexMoney = _stock.FindIndex(c => c.value == money.value && c.typeMoney == money.typeMoney);

        if (indexMoney == -1)
            return;

        var remainingQuantity = _stock[indexMoney].quantity - money.quantity;
        _stock[indexMoney] = money with { quantity = remainingQuantity };
    }
}