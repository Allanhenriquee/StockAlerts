using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.MappingConfigurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.ExchangeSymbol).HasColumnType("VARCHAR(10)").IsRequired();
        builder.Property(s => s.CompanyName).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(s => s.BusinessSector).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(s => s.CountryOfOrigin).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(s => s.Price).IsRequired();
        
        builder
            .HasMany(s => s.StockExchange)
            .WithMany(s => s.Stocks)
            .UsingEntity<Dictionary<string, object>>("StockStockExchanges",
                p => p.HasOne<StockExchange>().WithMany().HasForeignKey("StockExchangeId"),
                p => p.HasOne<Stock>().WithMany().HasForeignKey("StockId")
            );
    }
}