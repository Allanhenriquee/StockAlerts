using StockTracker.Application.Commands.StockExchange;

namespace StockTracker.Application.Commands.StocksCommands;

public class CreateStockWithStockExchangeCommand
{
    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string BusinessSector { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
    public ICollection<CreateStockExchangeCommand>? StockExchange { get; set; }
}