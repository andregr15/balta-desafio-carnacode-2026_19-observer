using src.Observer;

namespace src.Models;

public class InvestorV2(string name, decimal alertThreshold) : IStockObserver
{
    public string Name { get; set; } = name;
    public decimal AlertThreshold { get; set; } = alertThreshold;

    public void OnStockPriceChanged(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [Investidor {Name}] Notificado sobre {symbol}");

        if (Math.Abs(changePercent) >= AlertThreshold)
        {
            Console.WriteLine($"  → [Investidor {Name}] ⚠️ ALERTA! Mudança de {changePercent:+0.00;-0.00}% excedeu limite de {AlertThreshold}%");
        }
    }
}
