namespace StockTracker.Domain.Dtos;

public class GetAllStocksQueryDto
{
    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
}