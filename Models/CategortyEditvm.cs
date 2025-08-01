namespace InventoryMgmtSystem.Models;

public class CategortyEditvm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } 
}