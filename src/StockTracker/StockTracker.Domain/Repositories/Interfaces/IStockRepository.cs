using StockTracker.Domain.Dtos;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Domain.Repositories.Interfaces;

public interface IStockRepository
{
    Task CreateStock(Stock stock);
    Task<List<GetAllStocksQueryDto>> GetAllStock();
    Task<List<GetAllStocksQueryDto>> GetAllStockInactive();
    Task<Stock?> GetStockById(string id);
    Task<Stock>  GetStockByStockSymbol(string stockSymbol);
    Task UpdateStock(Stock stock);
    Task DeleteStock(Stock stock);
}