using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.Data;

public class StockTrackerContext : DbContext
{
    public StockTrackerContext(DbContextOptions<StockTrackerContext> options) : base(options) { }

    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<StockExchange> StockExchanges => Set<StockExchange>();
    public DbSet<WebhookSubscription> WebhookSubscriptions => Set<WebhookSubscription>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockTrackerContext).Assembly);
        CustomPropertiesMapping(modelBuilder);
    }

    private void CustomPropertiesMapping(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

            foreach (var property in properties)
            {
                if(string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    property.SetColumnType("VARCHAR(100)");
            }
        }
    }
}