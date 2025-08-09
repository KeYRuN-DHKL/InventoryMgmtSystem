using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Services.Interfaces;

namespace InventoryMgmtSystem.Services;

public class PurchaseService : IPurchaseService
{
    public readonly ApplicationDbContext _context;

    public PurchaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase> Create(PurchaseDto dto)
    {
        var purchase = new Purchase()
        {
            Id = Guid.NewGuid(),
            Amount = dto.Amount,
            Remark = dto.Remark,
            Tdate = dto.Tdate,
            InvoiceNo = dto.InvoiceNo,
            TaxableAmount = dto.TaxableAmount,
            TaxAmount = dto.TaxAmount,
            StakeHolderId = dto.StakeHolderId,
        };
        await _context.Purchases.AddAsync(purchase);
        await _context.SaveChangesAsync();
        return purchase;
    }
}