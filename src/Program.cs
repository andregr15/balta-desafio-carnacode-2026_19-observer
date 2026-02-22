using src.Subject;
using src.Models;

Console.WriteLine("=== Sistema de Monitoramento de Ações ===");

var petr4 = new StockV2("PETR4", 35.50m);

// Problema: Precisa registrar cada observador individualmente
var investor1 = new InvestorV2("João Silva", 3.0m);
var investor2 = new InvestorV2("Maria Santos", 5.0m);
var mobileApp = new MobileAppV2("user123");
var tradingBot = new TradingBotV2("AlgoTrader", 2.0m, 2.5m);

petr4.Subscribe(investor1);
petr4.Subscribe(investor2);
petr4.Subscribe(mobileApp);
petr4.Subscribe(tradingBot);

// Simulando mudanças de preço
Console.WriteLine("\n=== Movimentações do Mercado ===");

petr4.UpdatePrice(36.20m); // +1.97%
Thread.Sleep(500);

petr4.UpdatePrice(37.50m); // +3.59%
Thread.Sleep(500);

petr4.UpdatePrice(35.00m); // -6.67%
Thread.Sleep(500);

// Problema: Como adicionar um terceiro investidor?
// Precisaria adicionar _investor3 na classe Stock!

// Problema: Como remover observadores?
// Não há método de unregister!

// Console.WriteLine("\n=== PROBLEMAS ===");
// Console.WriteLine("✗ Acoplamento forte entre Stock e observadores específicos");
// Console.WriteLine("✗ Stock precisa conhecer cada tipo de observador");
// Console.WriteLine("✗ Adicionar novo observador = modificar classe Stock");
// Console.WriteLine("✗ Não suporta múltiplos observadores do mesmo tipo facilmente");
// Console.WriteLine("✗ Não há forma de remover observadores dinamicamente");
// Console.WriteLine("✗ Difícil adicionar novos tipos de notificação");
// Console.WriteLine("✗ Viola Open/Closed Principle");

// Console.WriteLine("\n=== Alternativa de Polling - Problemas ===");
// Console.WriteLine("✗ Latência (atraso entre mudança e detecção)");
// Console.WriteLine("✗ Desperdício de recursos (verificações constantes)");
// Console.WriteLine("✗ Não escala (milhares de ações × verificações por segundo)");
// Console.WriteLine("✗ Dificulta implementação de notificações em tempo real");

// Perguntas para reflexão:
// - Como desacoplar objeto observado dos observadores?
// - Como notificar múltiplos objetos automaticamente?
// - Como permitir subscrição/cancelamento dinâmico?
// - Como criar dependência um-para-muitos desacoplada?