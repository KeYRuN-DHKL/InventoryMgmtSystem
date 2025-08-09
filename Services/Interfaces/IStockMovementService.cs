using InventoryMgmtSystem.Dto;

namespace InventoryMgmtSystem.Services.Interfaces;

public interface IStockMovementService
{
    Task Create(List<StockMovementDto> dto);
}