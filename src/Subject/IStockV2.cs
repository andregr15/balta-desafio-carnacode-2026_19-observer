using src.Observer;

namespace src.Subject;

public interface IStockV2
{
    void Subscribe(IStockObserver observer);
    void Unsubscribe(IStockObserver observer);
    void NotifyOnPriceUpdate();
}
