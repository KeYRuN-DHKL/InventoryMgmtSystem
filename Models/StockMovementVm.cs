using InventoryMgmtSystem.Enums;

namespace InventoryMgmtSystem.Models;

public class StockMovementVm
{
    public Guid ProductId { get; set; }
    public MovementType Type { get; set; }
    public decimal Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal VatPer { get; set; }

}