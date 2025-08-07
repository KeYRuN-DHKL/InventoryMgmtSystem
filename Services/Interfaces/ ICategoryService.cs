using InventoryMgmtSystem.Models;

namespace InventoryMgmtSystem.services.Interfaces;

public interface ICategoryService
{
    Task<bool> CreateAsync(CategoryVm vm);
    Task<bool> UpdateAsync(CategoryEditVm vm);
    Task<bool> DeleteAsync(Guid id);
}