using StockTracker.Domain.Models.Entities;
using StockTracker.Domain.Repositories.Interfaces;
using StockTracker.Infrastructure.Data;

namespace StockTracker.Infrastructure.Repositories;

public class StockRepository : IStockRepository
{
    private readonly StockTrackerContext _context;

    public StockRepository(StockTrackerContext context)
    {
        _context = context;
    }

    public async Task CreateStock(Stock stock)
    {
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();
    }
}