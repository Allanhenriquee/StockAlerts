using MediatR;
using StockTracker.Domain.Commands.Interfaces;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Queries.StocksQueries.Handlers;

public class GetAllStocksInactiveQueryHandler : IRequestHandler<GetAllStocksInactiveQuery, GenericQueryResult>
{
    private readonly IStockRepository _stockRepository;

    public GetAllStocksInactiveQueryHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<GenericQueryResult> Handle(GetAllStocksInactiveQuery request, CancellationToken cancellationToken)
    {
        var stocks = await _stockRepository.GetAllStockInactive();

        return new GenericQueryResult(true, "Dados recuperado com sucesso", stocks);
    }
}