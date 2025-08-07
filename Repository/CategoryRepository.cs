using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgmtSystem.Repository;

public class CategoryRepository:ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<CategoryVm>> GetAllAsync()
    {
        return await _context.Categories
            .Select(c => new CategoryVm
            {
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive
            }).ToListAsync();
    }
}