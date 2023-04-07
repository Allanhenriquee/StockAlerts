using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.MappingConfigurations;

public class StockExchangeConfiguration : IEntityTypeConfiguration<StockExchange>
{
    public void Configure(EntityTypeBuilder<StockExchange> builder)
    {
        builder.ToTable("StockExchanges");
        
        builder.HasKey(s => s.Id);

        builder.Property(se => se.Id).HasColumnOrder(1);
        builder.Property(se => se.Name).HasColumnOrder(2).HasColumnType("VARCHAR(200)").IsRequired();
        builder.Property(se => se.Country).HasColumnOrder(3).HasColumnType("VARCHAR(200)").IsRequired();
        builder.Property(se => se.City).HasColumnOrder(4).HasColumnType("VARCHAR(200)").IsRequired();
        builder.Property(se => se.Currency).HasColumnOrder(5).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(se => se.ExchangeSymbol).HasColumnOrder(6).HasColumnType("VARCHAR(10)").IsRequired();
        builder.Property(se => se.Active).HasColumnOrder(7);
        builder.Property(se => se.CreatedAt).HasColumnOrder(8);
        builder.Property(se => se.UpdateAt).HasColumnOrder(9);
    }
}