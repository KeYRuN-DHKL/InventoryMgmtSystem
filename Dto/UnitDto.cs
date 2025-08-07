namespace InventoryMgmtSystem.Dto;

public class UnitDto
{
    public string FullName { get; set; }
    public string ShortName { get; set; } 
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}