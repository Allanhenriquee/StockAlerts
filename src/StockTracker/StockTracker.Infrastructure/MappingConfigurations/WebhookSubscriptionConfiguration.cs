using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Infrastructure.MappingConfigurations;

public class WebhookSubscriptionConfiguration : IEntityTypeConfiguration<WebhookSubscription>
{
    public void Configure(EntityTypeBuilder<WebhookSubscription> builder)
    {
        builder.ToTable("WebhookSubscriptions");
        
        builder.HasKey(s => s.Id);

        builder.Property(w => w.Id).HasColumnOrder(1);
        builder.Property(w => w.Url).HasColumnOrder(2).HasColumnType("VARCHAR(200)").IsRequired();
        builder.Property(w => w.Secret).HasColumnOrder(3).HasColumnType("VARCHAR(200)").IsRequired();
        builder.Property(w => w.WebhookType).HasColumnOrder(4).IsRequired();
        builder.Property(w => w.WebhookPublisher).HasColumnOrder(5).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(w => w.Active).HasColumnOrder(6);
        builder.Property(w => w.CreatedAt).HasColumnOrder(7);
        builder.Property(w => w.UpdateAt).HasColumnOrder(8);
    }
}