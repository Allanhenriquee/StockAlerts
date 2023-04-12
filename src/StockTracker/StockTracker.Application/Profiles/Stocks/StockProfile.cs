using AutoMapper;
using StockTracker.Application.Commands.StocksCommands;
using StockTracker.Application.Dtos.StockCommand;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Application.Profiles.Stocks;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<CreateStockCommand, Stock>();
        
        CreateMap<Stock, CreateStockCommandResult>();
    }
}