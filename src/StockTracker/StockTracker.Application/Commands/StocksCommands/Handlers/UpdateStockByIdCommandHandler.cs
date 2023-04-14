using AutoMapper;
using MediatR;
using StockTracker.Application.Dtos.StockCommand;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands.Handlers;

public class UpdateStockByIdCommandHandler : IRequestHandler<UpdateStockByIdCommand, GenericCommandResult>
{
    private readonly IStockRepository _stockRepository;
    private readonly IMapper _mapper;

    public UpdateStockByIdCommandHandler(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;
    }

    public async Task<GenericCommandResult> Handle(UpdateStockByIdCommand request, CancellationToken cancellationToken)
    {
        request.Validate();

        if (request.Invalid)
            return new GenericCommandResult(false,
                "Não foi possível realizar essa alteração.",
                request.Notifications);

        if (request.Id == null)
            return new GenericCommandResult(false,
                "Não foi possível realizar essa alteração.",
                request);

        var stock = await _stockRepository.GetStockById(request.Id);

        if (stock == null)
            return new GenericCommandResult(false,
                $"Não foi possível encontrar a ação com o Id {request.Id}",
                request.Notifications);

        stock.UpdatePrice(request.Price);

        await _stockRepository.UpdateStock(stock);

        var updateStockCommandResult = _mapper.Map<UpdateStockCommandResult>(stock);

        return new GenericCommandResult(true, "Price atualizado com sucesso!", updateStockCommandResult);
    }
}