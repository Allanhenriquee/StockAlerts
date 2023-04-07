using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockTracker.Application.Commands.StocksCommands;
using StockTracker.Domain.Repositories.Interfaces;


namespace StockTracker.API.Controllers;

[ApiController]
[Route("api/v1/stocks")]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepository;
    private readonly IMediator _mediator;
    public StockController(IStockRepository stockRepository, IMediator mediator)
    {
        _stockRepository = stockRepository;
        _mediator = mediator;
    }

    [HttpPost("create-stock")]
    public async Task<IActionResult> CreateStock(CreateStockCommand model)
    {
        var result = await _mediator.Send(model);

        return Ok(result);
    }

    [HttpPost("create-stock-with-stock-exchange")]
    public async Task<IActionResult> CreateStock(CreateStockWithStockExchangeCommand model)
    {
        return Ok();
    }
}