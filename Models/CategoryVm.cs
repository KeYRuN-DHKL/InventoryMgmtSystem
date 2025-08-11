namespace InventoryMgmtSystem.Models;

public class CategoryVm
{
    public Guid Id { get; set; } 
    public  string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}