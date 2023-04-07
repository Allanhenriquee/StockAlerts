using MediatR;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Models.Entities;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands.Handlers;

public class CreateStockHandler : IRequestHandler<CreateStockCommand, GenericCommandResult>
{
    private readonly IStockRepository _stockRepository;

    public CreateStockHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<GenericCommandResult> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        request.Validate();
        
        if(request.Invalid)
            return new GenericCommandResult(false, 
                $"Não foi possível cadastrar a Ação {request.StockSymbol} da Empresa {request.CompanyName}", 
                request.Notifications);
        
        var stock = new Stock
        {
            StockSymbol = request.StockSymbol,
            CompanyName = request.CompanyName,
            BusinessSector = request.BusinessSector,
            CountryOfOrigin = request.CountryOfOrigin,
            Price = request.Price
        };
        
        await _stockRepository.CreateStock(stock);
        
        return new GenericCommandResult(true,
            $"Ação {request.StockSymbol} da Empresa {request.CompanyName} cadastrada com sucesso!",
            stock);
    }
}