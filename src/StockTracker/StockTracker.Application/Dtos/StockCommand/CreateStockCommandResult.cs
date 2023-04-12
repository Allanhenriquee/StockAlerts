namespace StockTracker.Application.Dtos.StockCommand;

public class CreateStockCommandResult
{
    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string BusinessSector { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}