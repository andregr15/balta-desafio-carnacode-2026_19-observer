using src.Observer;

namespace src.Subject;

public class StockV2(string symbol, decimal initialPrice) : IStockV2
{
    public string Symbol { get; set; } = symbol;
    public decimal Price { get; private set; } = initialPrice;
    public DateTime LastUpdate { get; private set; } = DateTime.Now;
    public decimal ChangePercent { get; private set; } = 0m;

    private readonly List<IStockObserver> _observers = [];

    public void Subscribe(IStockObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Unsubscribe(IStockObserver observer) =>
        _observers.Remove(observer);

    public void NotifyOnPriceUpdate() =>
        _observers.ForEach(observer => observer.OnStockPriceChanged(Symbol, Price, ChangePercent));

    public void UpdatePrice(decimal newPrice)
    {
        if (Price != newPrice)
        {
            decimal oldPrice = Price;
            Price = newPrice;
            LastUpdate = DateTime.Now;

            ChangePercent = ((newPrice - oldPrice) / oldPrice) * 100;

            Console.WriteLine($"\n[{Symbol}] Preço atualizado: R$ {oldPrice:N2} → R$ {newPrice:N2} ({ChangePercent:+0.00;-0.00}%)");

            NotifyOnPriceUpdate();
        }
    }
}
