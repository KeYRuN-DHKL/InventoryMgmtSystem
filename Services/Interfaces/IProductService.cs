using InventoryMgmtSystem.Models;

namespace InventoryMgmtSystem.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductVm>> GetAllAsync();
    Task<ProductEditVm?> GetByIdAsync(Guid id);
    Task CreateAsync(ProductVm vm);
    Task UpdateAsync(ProductEditVm vm);
    Task DeleteAsync(Guid id);
}