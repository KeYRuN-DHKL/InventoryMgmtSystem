using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMgmtSystem.Models;

public class ProductVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UnitId { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal CostPrice { get; set; }
    
    
    public List<SelectListItem>? Categories { get; set; } = new List<SelectListItem>();
    public List<SelectListItem>? Units { get; set; } = new List<SelectListItem>();
}