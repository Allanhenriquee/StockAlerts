﻿using StockTracker.Domain.Models.Entities.BaseEntity;

namespace StockTracker.Domain.Models.Entities;

public class Stock : Entity
{
    public string Code { get; set; }
    public string ExchangeSymbol { get; set; }
    public string CompanyName { get; set; }
    public string BusinessSector { get; set; }
    public string CountryOfOrigin { get; set; }
    public double Price { get; set; }
    public ICollection<StockExchange> StockExchange { get; set; }
}