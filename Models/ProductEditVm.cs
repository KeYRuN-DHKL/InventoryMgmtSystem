using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMgmtSystem.Models;

public class ProductEditVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public List<SelectListItem>? Units { get; set; } = new List<SelectListItem>();
    public Guid UnitId { get; set; }
}