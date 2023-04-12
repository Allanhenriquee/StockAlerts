

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
            .IsNotNullOrEmpty(StockSymbol, "StockSymbol", "Stock Symbol não pode ser vazio")
            .HasMinLen(StockSymbol, 3, "StockSymbol", "Stock Symbol deve ter entre 3 e 10 caracteres")
            .HasMaxLen(StockSymbol, 10, "StockSymbol", "Stock Symbol deve ter entre 3 e 10 caracteres")
            
            .IsNotNullOrEmpty(CompanyName, "CompanyName", "Company Name não pode ser vazio")
            .HasMinLen(CompanyName, 3, "CompanyName", "Company Name deve ter entre 3 e 200 caracteres")
            .HasMaxLen(CompanyName, 200, "CompanyName", "Company Name deve ter entre 3 e 200 caracteres")
            
            .IsNullOrEmpty(BusinessSector, "BusinessSector", "Business Sector não pode ser vazio")
            .HasMinLen(BusinessSector, 3, "BusinessSector", "Business Sector deve ter entre 3 e 100 caracteres")
            .HasMaxLen(BusinessSector, 100, "BusinessSector", "Business Sector deve ter entre 3 e 100 caracteres")
            
            .IsNotNullOrEmpty(CountryOfOrigin, "CountryOfOrigin", "Country Of Origin não pode ser vazio")
            .HasMinLen(CountryOfOrigin, 3, "CountryOfOrigin", "Country Of Origin deve ter entre 3 e 200 caracteres")
            .HasMaxLen(CountryOfOrigin, 200, "CountryOfOrigin", "Country Of Origin deve ter entre 3 e 200 caracteres")
            
            .IsGreaterThan(Price, 0, "Price", "Price deve ser maior que zero")
        );
    }
}