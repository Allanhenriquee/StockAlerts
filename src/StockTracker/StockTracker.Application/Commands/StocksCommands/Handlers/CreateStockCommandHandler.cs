using AutoMapper;
using MediatR;
using StockTracker.Application.Dtos.StockCommand;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Models.Entities;
using StockTracker.Domain.Repositories.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands.Handlers;

public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, GenericCommandResult>
{
    private readonly IStockRepository _stockRepository;
    private readonly IMapper _mapper;

    public CreateStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;
    }

    public async Task<GenericCommandResult> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        request.Validate();
        
        if(request.Invalid)
            return new GenericCommandResult(false, 
                $"Não foi possível cadastrar a Ação {request.StockSymbol} da Empresa {request.CompanyName}", 
                request.Notifications);
        
        var stock = _mapper.Map<Stock>(request);
        
        await _stockRepository.CreateStock(stock);
        
        var stockCommandResult = _mapper.Map<CreateStockCommandResult>(stock);
        
        return new GenericCommandResult(true,
            $"Ação {stockCommandResult.StockSymbol} - Empresa {stockCommandResult.CompanyName} - Cadastrado com sucesso! :) ",
            stockCommandResult);
    }
}