using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace InventoryMgmtSystem.Controllers;

public class CategoryController:Controller
{
     private readonly ApplicationDbContext _context;
    private readonly IToastNotification _toastNotification;

    public CategoryController(ApplicationDbContext context, IToastNotification toastNotification)
    {
        _context = context;
        _toastNotification = toastNotification;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories.ToListAsync();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryVm vm)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                Quantity = vm.Quantity,
                Price = vm.Price,
                Description = vm.Description
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "An error occurred while creating the category: " + e.Message);
            return View(vm);
        }
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);
            var vm = new CategortyEditvm
            {
                Id = category.Id,
                Name = category.Name,
                Quantity = category.Quantity,
                Price = category.Price,
                Description = category.Description,
                IsActive = category.IsActive
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
    public async Task<IActionResult> Edit(CategortyEditvm vm)
    {
        try
        {
            if (!ModelState.IsValid) return View(vm);

            var category = await _context.Categories.FindAsync(vm.Id);
            if (category == null)
            {
                _toastNotification.AddAlertToastMessage("Category Not Found");
                return RedirectToAction("Index");
            }

            category.Name = vm.Name;
            category.Quantity = vm.Quantity;
            category.Price = vm.Price;
            category.Description = vm.Description;
            category.IsActive = vm.IsActive;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage("Category Updated Successfully");
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return View(vm);
        }
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                _toastNotification.AddErrorToastMessage("Category not found.");
                return RedirectToAction("Index");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            _toastNotification.AddSuccessToastMessage("Category deleted successfully.");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _toastNotification.AddErrorToastMessage("Error deleting category: " + ex.Message);
            return RedirectToAction("Index");
        }
    }
}