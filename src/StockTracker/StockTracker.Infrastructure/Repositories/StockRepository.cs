using Microsoft.EntityFrameworkCore;
using StockTracker.Application.Queries.HelperQueries;
using StockTracker.Domain.Dtos;
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

    public async Task<List<GetAllStocksQueryDto>> GetAllStock()
    {
        var stocks = await _context.Stocks
            .Where(StockHelperQuery.GetAllActive())
            .Select(s => new GetAllStocksQueryDto
            {
                StockSymbol = s.StockSymbol,
                CompanyName = s.CompanyName,
                CountryOfOrigin = s.CountryOfOrigin,
                Price = s.Price
            }).ToListAsync();

        return stocks;
    }

    public async Task<List<GetAllStocksQueryDto>> GetAllStockInactive()
    {
        var stocks = await _context.Stocks
            .Where(StockHelperQuery.GetAllInactive())
            .Select(s => new GetAllStocksQueryDto
            {
                StockSymbol = s.StockSymbol,
                CompanyName = s.CompanyName,
                CountryOfOrigin = s.CountryOfOrigin,
                Price = s.Price
            }).ToListAsync();

        return stocks;
    }

    public async Task<Stock> GetStockById(string id)
    {
        var stock = await _context.Stocks.SingleOrDefaultAsync(s => s.Id == id);
        return stock;
    }

    public async Task<Stock> GetStockByStockSymbol(string stockSymbol)
    {
        var stock = await _context.Stocks.SingleOrDefaultAsync(s => s.StockSymbol == stockSymbol);
        return stock;
    }

    public async Task UpdateStock(Stock stock)
    {
        _context.Stocks.Update(stock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStock(Stock stock)
    {
        throw new NotImplementedException();
    }
}