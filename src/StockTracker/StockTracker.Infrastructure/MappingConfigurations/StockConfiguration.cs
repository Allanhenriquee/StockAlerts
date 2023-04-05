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

        builder.Property(s => s.Id).HasColumnOrder(1);
        builder.Property(s => s.StockSymbol).HasColumnType("VARCHAR(10)").HasColumnOrder(2).IsRequired();
        builder.Property(s => s.CompanyName).HasColumnType("VARCHAR(200)").HasColumnOrder(3).IsRequired();
        builder.Property(s => s.BusinessSector).HasColumnType("VARCHAR(100)").HasColumnOrder(4).IsRequired();
        builder.Property(s => s.CountryOfOrigin).HasColumnType("VARCHAR(200)").HasColumnOrder(5).IsRequired();
        builder.Property(s => s.Price).HasColumnOrder(6).IsRequired();
        builder.Property(s => s.Active).HasColumnOrder(7);
        builder.Property(s => s.CreatedAt).HasColumnOrder(8);
        builder.Property(s => s.UpdateAt).HasColumnOrder(9);
        
        builder
            .HasMany(s => s.StockExchange)
            .WithMany(s => s.Stocks)
            .UsingEntity<Dictionary<string, object>>("StockExchangeRelationship",
                se => se.HasOne<StockExchange>().WithMany().HasForeignKey("StockExchangeId"),
                s => s.HasOne<Stock>().WithMany().HasForeignKey("StockId"),
                p => p.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()")
            );
    }
}