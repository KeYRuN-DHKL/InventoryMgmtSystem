using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgmtSystem.Repository;

public class StakeHolderRepository:IStakeHolderRepository
{
    private readonly ApplicationDbContext _context;

    public StakeHolderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StakeHolderVm>> GetAllAsync()
    {
        return await _context.StakeHolders
            .Select(s => new StakeHolderVm
            {
                ID = s.ID,
                Name = s.Name,
                Address = s.Address,
                Contact = s.Contact,
                Email = s.Email,
                Vat = s.Vat,
                Type = s.Type
            }).ToListAsync();
    }
    
    public async Task<StakeHolderVm?> GetByIdAsync(Guid id)
    {
        return await _context.StakeHolders
            .Where(s => s.ID == id)
            .Select(s => new StakeHolderVm
            {
                ID = s.ID,
                Name = s.Name,
                Address = s.Address,
                Contact = s.Contact,
                Email = s.Email,
                Vat = s.Vat,
                Type = s.Type
            }).FirstOrDefaultAsync();
    }
}