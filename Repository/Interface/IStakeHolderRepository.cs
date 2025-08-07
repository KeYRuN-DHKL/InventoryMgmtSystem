using InventoryMgmtSystem.Models;

namespace InventoryMgmtSystem.Repository.Interface
{
    public interface IStakeHolderRepository
    {
        Task<List<StakeHolderVm>> GetAllAsync();
        Task<StakeHolderVm?> GetByIdAsync(Guid id);
    }
}