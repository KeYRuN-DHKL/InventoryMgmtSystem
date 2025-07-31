namespace InventoryMgmtSystem.Models;

public class CategoryVm
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    
    public string? Description { get; set; }
}