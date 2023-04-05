using StockTracker.Domain.Enums;
using StockTracker.Domain.Models.Entities.BaseEntity;

namespace StockTracker.Domain.Models.Entities;

public class WebhookSubscription : Entity
{
    public string Url { get; set; }
    public string Secret { get; set; }
    public WebhookTypeEnum WebhookType { get; set; }
    public string WebhookPublisher { get; set; }
}