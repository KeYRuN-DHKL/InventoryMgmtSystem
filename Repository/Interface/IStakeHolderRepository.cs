using InventoryMgmtSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMgmtSystem.Repository.Interface
{
    public interface IStakeHolderRepository
    {
        Task<List<StakeHolderVm>> GetAllAsync();
        Task<StakeHolderVm?> GetByIdAsync(Guid id);
        Task<List<SelectListItem>> GetStakeHolderList();
    }
}