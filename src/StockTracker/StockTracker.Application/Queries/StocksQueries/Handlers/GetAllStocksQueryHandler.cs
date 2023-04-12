using MediatR;
using StockTracker.Domain.Commands.Interfaces;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Queries.StocksQueries.Handlers;

public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, GenericQueryResult>
{
    private readonly IStockRepository _stockRepository;
    
    public GetAllStocksQueryHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<GenericQueryResult> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
    {
        var stocks = await _stockRepository.GetAllStock();

        return new GenericQueryResult(true, "Dados recuperado com sucesso", stocks);
    }
}