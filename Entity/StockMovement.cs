using InventoryMgmtSystem.Enums;
namespace InventoryMgmtSystem.Entity;

public class StockMovement
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public Guid TypeId { get; set; }
    public MovementType Type { get; set; }
    public decimal Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal VatPer { get; set; }
    public Stock Stock { get; set; }
}