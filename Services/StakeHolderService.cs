using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Services.Interfaces;

namespace InventoryMgmtSystem.Services;

public class StakeHolderService:IStakeHolderService
{
    private readonly ApplicationDbContext _context;

    public StakeHolderService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(StakeHolderDto dto)
    {
        var entity = new StakeHolder
        {
            ID = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Contact = dto.Contact,
            Email = dto.Email,
            Vat = dto.VatP,
            Type = dto.Type
        };

        _context.StakeHolders.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(StakeHolderEditVm vm)
    {
        var entity = await _context.StakeHolders.FindAsync(vm.ID);
        if (entity == null) return false;

        entity.Name = vm.Name;
        entity.Address = vm.Address;
        entity.Contact = vm.Contact;
        entity.Email = vm.Email;
        entity.Vat = vm.Vat;
        entity.Type = vm.Type;

        _context.StakeHolders.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.StakeHolders.FindAsync(id);
        if (entity == null) return false;

        _context.StakeHolders.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}