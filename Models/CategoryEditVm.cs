namespace InventoryMgmtSystem.Models;

public class CategoryEditVm
{
    public Guid Id { get; set; }
    public  string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } 
}