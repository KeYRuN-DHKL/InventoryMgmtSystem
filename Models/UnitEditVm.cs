namespace InventoryMgmtSystem.Models;

public class UnitEditVm
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; } 
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}