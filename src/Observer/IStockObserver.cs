namespace src.Observer;

public interface IStockObserver
{
    void OnStockPriceChanged(string symbol, decimal price, decimal changePercent);
}
