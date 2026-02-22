using src.Observer;

namespace src.Models;

public class TradingBotV2(string botName, decimal buyThreshold, decimal sellThreshold) : IStockObserver
{
    public string BotName { get; set; } = botName;
    public decimal BuyThreshold { get; set; } = buyThreshold;
    public decimal SellThreshold { get; set; } = sellThreshold;

    public void OnStockPriceChanged(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [Bot {BotName}] 🤖 Analisando {symbol}...");

        if (changePercent <= -BuyThreshold)
        {
            Console.WriteLine($"  → [Bot {BotName}] 💰 COMPRANDO {symbol} por R$ {price:N2}");
        }
        else if (changePercent >= SellThreshold)
        {
            Console.WriteLine($"  → [Bot {BotName}] 💸 VENDENDO {symbol} por R$ {price:N2}");
        }
    }
}
