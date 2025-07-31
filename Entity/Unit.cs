namespace InventoryMgmtSystem.Entity;

public class Unit
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; } 
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}