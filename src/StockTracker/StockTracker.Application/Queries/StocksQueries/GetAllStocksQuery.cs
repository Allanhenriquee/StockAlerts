using MediatR;
using StockTracker.Domain.Commands.Interfaces;


namespace StockTracker.Application.Queries.StocksQueries;

public class GetAllStocksQuery : IRequest<GenericQueryResult>
{
    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
}