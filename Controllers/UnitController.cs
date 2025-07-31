using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace InventoryMgmtSystem.Controllers;

public class UnitController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IToastNotification _toastNotification;

    public UnitController(ApplicationDbContext context, IToastNotification toastNotification)
    {
        _context = context;
        _toastNotification = toastNotification;
    }

    public async Task<IActionResult> Index()
    {
        var units = await _context.Units.ToListAsync();
        return View(units);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UnitVm vm)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var unit = new Unit
            {
                Id = Guid.NewGuid(),
                FullName = vm.FullName,
                ShortName = vm.ShortName,
                Description = vm.Description,
            };
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "An error occurred while creating the unit: " + e.Message);
            return View(vm);
        }
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        try
        {
            var unit = await _context.Units.FindAsync(id);
            var vm = new UnitEditVm
            {
                Id = unit.Id,
                FullName = unit.FullName,
                ShortName = unit.ShortName,
                Description = unit.Description,
                IsActive = unit.IsActive

            };
            return View(vm);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UnitEditVm vm)
    {
        try
        {
            if (!ModelState.IsValid) return View(vm);

            var unit = await _context.Units.FindAsync(vm.Id);
            if (unit == null)
            {
                _toastNotification.AddAlertToastMessage("Unt Not Found");
                return RedirectToAction("Index");
            }

            unit.FullName = vm.FullName;
            unit.ShortName = vm.ShortName;
            unit.Description = vm.Description;
            unit.IsActive = vm.IsActive;
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage("Unit Updated Successfully");
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                _toastNotification.AddErrorToastMessage("Unit not found.");
                return RedirectToAction("Index");
            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            _toastNotification.AddSuccessToastMessage("Unit deleted successfully.");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _toastNotification.AddErrorToastMessage("Error deleting unit: " + ex.Message);
            return RedirectToAction("Index");
        }
    }
}