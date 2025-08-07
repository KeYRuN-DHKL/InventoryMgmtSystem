namespace InventoryMgmtSystem.Dto;

public class CategoryDto
{
    public  string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}