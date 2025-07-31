namespace InventoryMgmtSystem.Models;

public class ProductVm
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid UnitId { get; set; }
}