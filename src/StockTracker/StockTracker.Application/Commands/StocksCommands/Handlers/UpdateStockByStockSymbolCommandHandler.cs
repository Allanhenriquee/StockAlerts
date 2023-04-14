using AutoMapper;
using MediatR;
using StockTracker.Application.Dtos.StockCommand;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands.Handlers;

public class UpdateStockByStockSymbolCommandHandler : IRequestHandler<UpdateStockByStockSymbolCommand, GenericCommandResult>
{
    private readonly IStockRepository _stockRepository;
    private readonly IMapper _mapper;

    public UpdateStockByStockSymbolCommandHandler(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;
    }

    public async Task<GenericCommandResult> Handle(UpdateStockByStockSymbolCommand request, CancellationToken cancellationToken)
    {
        request.Validate();
        
        if(request.Invalid)
            return new GenericCommandResult(false, 
                "Não foi possível realizar essa alteração.", 
                request.Notifications);

        if (request.StockSymbol == null)
            return new GenericCommandResult(false,
                "Não foi possível realizar essa alteração.",
                request);
        
        var stock = await _stockRepository.GetStockByStockSymbol(request.StockSymbol);
        
        if (stock == null)
            return new GenericCommandResult(false,
                $"Não foi possível encontrar a ação com o StockSymbol: {request.StockSymbol}",
                request.Notifications);

        stock.UpdatePrice(request.Price);

        await _stockRepository.UpdateStock(stock);

        var updateStockCommandResult = _mapper.Map<UpdateStockCommandResult>(stock);

        return new GenericCommandResult(true, "Price atualizado com sucesso!", updateStockCommandResult);

    }
}