using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Entity;

namespace InventoryMgmtSystem.Services.Interfaces;

public interface ISalesService
{
    Task<Sale> Create(SaleDto dto);

    Task<String> CreateInvoiceNumber();
}