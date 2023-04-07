using StockTracker.Domain.Models.Entities.BaseEntity;

namespace StockTracker.Domain.Models.Entities;

public class Stock : Entity
{
    public Stock(string stockSymbol, string companyName, string businessSector, string countryOfOrigin, decimal price)
    {
        StockSymbol = stockSymbol;
        CompanyName = companyName;
        BusinessSector = businessSector;
        CountryOfOrigin = countryOfOrigin;
        Price = price;
    }

    public Stock()
    {
    }

    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string BusinessSector { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
    public ICollection<StockExchange>? StockExchange { get; set; }
}