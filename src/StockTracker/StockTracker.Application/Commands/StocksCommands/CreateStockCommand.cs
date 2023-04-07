

using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StockTracker.Domain.Commands;
using StockTracker.Domain.Commands.Interfaces;

namespace StockTracker.Application.Commands.StocksCommands;

public class CreateStockCommand : Notifiable, IRequest<GenericCommandResult>, ICommand
{
    public CreateStockCommand() { }
    
    public CreateStockCommand(string stockSymbol, string companyName, string businessSector, string countryOfOrigin, decimal price)
    {
        StockSymbol = stockSymbol;
        CompanyName = companyName;
        BusinessSector = businessSector;
        CountryOfOrigin = countryOfOrigin;
        Price = price;
    }

    public string StockSymbol { get; set; }
    public string CompanyName { get; set; }
    public string BusinessSector { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMaxLen(StockSymbol, 10, "StockSymbol", "Stock Symbol deve ter menos de 10 caracteres")
            .IsGreaterThan(Price, 0, "Price", "Price deve ser maior que zero")
        );
    }
}