using InventoryMgmtSystem.Enums;

namespace InventoryMgmtSystem.Dto;

public class StockMovementDto
{
    
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid TypeId { get; set; }
    public MovementType Type { get; set; }
    public decimal Quantity { get; set; }
    public decimal Rate { get; set; }
    public Stock Stock { get; set; }
}