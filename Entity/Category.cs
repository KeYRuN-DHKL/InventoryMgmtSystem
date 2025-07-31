namespace InventoryMgmtSystem.Entity;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Description { get; set; }
}