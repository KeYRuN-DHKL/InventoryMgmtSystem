namespace InventoryMgmtSystem.Dto;

public class ProductDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public decimal CostPrice { get; set; }
    public Guid UnitId { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}