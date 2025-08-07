using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Models;

namespace InventoryMgmtSystem.Services.Interfaces
{
    public interface IStakeHolderService
    {
        Task CreateAsync(StakeHolderDto dto);
        Task<bool> UpdateAsync(StakeHolderEditVm vm);
        Task<bool> DeleteAsync(Guid id);
    }
}