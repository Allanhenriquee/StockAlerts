namespace StockTracker.Application.Commands.StockExchange;

public class CreateStockExchangeCommand
{
    public string ExchangeSymbol { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Currency { get; set; }
}