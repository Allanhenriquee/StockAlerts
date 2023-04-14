using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockTracker.Application.Commands.StocksCommands;
using StockTracker.Application.Queries.StocksQueries;


namespace StockTracker.API.Controllers;

[ApiController]
[Route("api/v1/stocks")]
public class StockController : ControllerBase
{
    private readonly IMediator _mediator;
    public StockController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create-stock")]
    public async Task<IActionResult> CreateStock(CreateStockCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPut("update-stock-by-id/{Id}")]
    public async Task<IActionResult> UpdateStockById(string id, UpdateStockByIdCommand command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPut("update-stock-by-stock-symbol/{StockSymbol}")]
    public async Task<IActionResult> UpdateStockByStockSymbol(string stockSymbol, UpdateStockByStockSymbolCommand command)
    {
        command.StockSymbol = stockSymbol;
        return Ok(await _mediator.Send(command));
    }
    
    [HttpGet("get-all-stocks")]
    public async Task<IActionResult> GetAllStocks()
    {
        return Ok(await _mediator.Send(new GetAllStocksQuery()));
    }
    [HttpGet("get-all-stocks-inactive")]
    public async Task<IActionResult> GetAllStocksInactive()
    {
        return Ok(await _mediator.Send(new GetAllStocksInactiveQuery()));
    }

    [HttpPost("create-stock-with-stock-exchange")]
    public async Task<IActionResult> CreateStock(CreateStockWithStockExchangeCommand model)
    {
        return Ok();
    }
}