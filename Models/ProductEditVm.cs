namespace InventoryMgmtSystem.Models;

public class ProductEditVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid UnitId { get; set; }
}