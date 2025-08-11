using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMgmtSystem.Repository.Interface;

public interface IProductRepository
{
    Task<List<SelectListItem>> GetProductList();
}