using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgmtSystem.Services;

public class SalesService:ISalesService
{
    private readonly ApplicationDbContext _context;

    public SalesService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Sale> Create(SaleDto dto)
    {
        var sale = new Sale()
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
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<string> CreateInvoiceNumber()
    {
        var LastInvoice = await _context.Sales.OrderByDescending(e => e.InvoiceNo).FirstOrDefaultAsync(); 
        int InvoiceNumber = 1;
        if (LastInvoice != null)
        {
            InvoiceNumber = int.Parse(LastInvoice.InvoiceNo) + 1;
        }

        return InvoiceNumber.ToString();
    }
}