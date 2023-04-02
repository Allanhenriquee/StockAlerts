using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.MappingConfigurations;

public class StockExchangeConfiguration : IEntityTypeConfiguration<StockExchange>
{
    public void Configure(EntityTypeBuilder<StockExchange> builder)
    {
        builder.HasKey(s => s.Id);
    }
}