using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgmtSystem.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CreateAsync(CategoryVm vm)
    {
        var category = new Category
        {
            Name = vm.Name,
            Description = vm.Description,
            IsActive = vm.IsActive
        };

        _context.Categories.Add(category);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(CategoryEditVm vm)
    {
        var category = await _context.Categories.FindAsync(vm.Id);
        if (category == null) return false;

        category.Id = vm.Id;
        category.Name = vm.Name;
        category.Description = vm.Description;
        category.IsActive = vm.IsActive;

        _context.Categories.Update(category);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        return await _context.SaveChangesAsync() > 0;
    }
}
