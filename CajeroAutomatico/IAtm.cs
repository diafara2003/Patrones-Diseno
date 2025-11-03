namespace CajeroAutomatico;

public record Money(int value, TipoMoney typeMoney);

public enum TipoMoney
{
    bill,
    coin
}

public interface IAtm
{
    public List<Money> Withdraw(int quantity);
    public List<Money> GetBalance();
}