using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgmtSystem.Repository;

public class ProductRepository : IProductRepository
{
    public readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SelectListItem>> GetProductList()
    {
        return await _context.Products.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Name
        }).ToListAsync();
    }
}