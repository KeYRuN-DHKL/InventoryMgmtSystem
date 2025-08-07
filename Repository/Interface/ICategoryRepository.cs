using InventoryMgmtSystem.Models;
namespace InventoryMgmtSystem.Repository.Interface;

public interface ICategoryRepository
{
    Task<List<CategoryVm>> GetAllAsync();
}