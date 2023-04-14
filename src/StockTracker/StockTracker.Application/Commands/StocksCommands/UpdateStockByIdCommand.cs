using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Commands.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands;

public class UpdateStockByIdCommand : Notifiable, IRequest<GenericCommandResult>, ICommand
{
    public string? Id { get; set; }
    public decimal Price { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract()
            .IsNotNullOrEmpty(Id, "Id", "Id não pode ser vazio")
            .IsGreaterThan(Price, 0, "Price", "Price deve ser maior que zero")
        );
    }
}