using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Commands.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands;

public class UpdateStockByStockSymbolCommand : Notifiable, IRequest<GenericCommandResult>, ICommand
{
    public string? StockSymbol { get; set; }
    public decimal Price { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .IsNotNullOrEmpty(StockSymbol, "StockSymbol", "StockSymbol não pode ser vazio")
            .IsGreaterThan(Price, 0, "Price", "Price deve ser maior que zero")
        );
    }
}