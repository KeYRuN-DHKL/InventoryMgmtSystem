using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Enums;
using InventoryMgmtSystem.Services.Interfaces;

namespace InventoryMgmtSystem.Services;

public class StockMovementService:IStockMovementService
{
    public readonly ApplicationDbContext _context;

    public StockMovementService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(List<StockMovementDto> dto)
    {
        var stockmovement = dto.Select(item => new StockMovement
        {
            Id = Guid.NewGuid(),
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            Rate = item.Rate,
            Stock = item.Stock,
            Type = item.Type,
            TypeId = item.TypeId,
            VatPer = item.VatPer,
        }).ToList();
        await _context.StockMovements.AddRangeAsync(stockmovement);
        await _context.SaveChangesAsync();
    }
}