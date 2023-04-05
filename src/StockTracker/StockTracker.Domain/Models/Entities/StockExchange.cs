using StockTracker.Domain.Enums;
using StockTracker.Domain.Models.Entities.BaseEntity;

namespace StockTracker.Domain.Models.Entities;

public class StockExchange : Entity
{
    public string ExchangeSymbol { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public CurrencyTypeEnum Currency { get; set; }
    public ICollection<Stock> Stocks { get; set; }
}