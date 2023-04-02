namespace StockTracker.Domain.Models.Entities.BaseEntity;

public abstract class Entity
{
    public string Id { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
        Active = true;
        CreatedAt = DateTime.Now;
    }
}