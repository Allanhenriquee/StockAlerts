using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.MappingConfigurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder
            .HasMany(s => s.StockExchange)
            .WithMany(s => s.Stocks)
            .UsingEntity<Dictionary<string, object>>("StockStockExchange",
                p => p.HasOne<StockExchange>().WithMany().HasForeignKey("StockExchangeId"),
                p => p.HasOne<Stock>().WithMany().HasForeignKey("StockId")
            );
    }
}