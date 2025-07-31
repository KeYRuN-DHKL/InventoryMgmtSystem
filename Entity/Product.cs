namespace InventoryMgmtSystem.Entity;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UnitId { get; set; }
    public virtual Unit Unit { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}