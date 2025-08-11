using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMgmtSystem.Models;

public class SalesVm
{
    public DateOnly Tdate { get; set; }
    public Guid StakeHolderId { get; set; }
    public string InvoiceNo { get; set; }
    public decimal Amount { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public string? Remark { get; set; }
    public decimal Total => Amount + TaxAmount;

    public List<SelectListItem>? StakeHolders { get; set; } = new List<SelectListItem>();
    
    public List<SelectListItem>? Products { get; set; } = new List<SelectListItem>();
    
    public List<StockMovementVm> StockMovement { get; set; } = new List<StockMovementVm>();


}