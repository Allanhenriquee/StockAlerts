﻿using StockTracker.Domain.Models.Entities;

namespace StockTracker.Domain.Repositories.Interfaces;

public interface IStockRepository
{
    Task CreateStock(Stock stock);
}