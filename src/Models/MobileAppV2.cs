using src.Observer;

namespace src.Models;

public class MobileAppV2(string userId) : IStockObserver
{
    public string UserId { get; set; } = userId;

    public void OnStockPriceChanged(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [App Mobile {UserId}] 📱 Push: {symbol} agora em R$ {price:N2} ({changePercent:+0.00;-0.00}%)");
    }
}
