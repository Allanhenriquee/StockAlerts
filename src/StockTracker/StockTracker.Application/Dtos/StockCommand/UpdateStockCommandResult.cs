namespace StockTracker.Application.Dtos.StockCommand;

public class UpdateStockCommandResult
{
    public string StockSymbol { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdateAt { get; set; }
}