using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using InventoryMgmtSystem.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace InventoryMgmtSystem.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IToastNotification _toastNotification;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryService categoryService, IToastNotification toastNotification,ICategoryRepository categoryrepository)
    {
        _categoryService = categoryService;
        _toastNotification = toastNotification;
        _categoryRepository = categoryrepository;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return View(categories);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CategoryVm vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var success = await _categoryService.CreateAsync(vm);
        if (success)
        {
            _toastNotification.AddSuccessToastMessage("Category created successfully.");
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Error occurred while creating category.");
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryEditVm vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var success = await _categoryService.UpdateAsync(vm);
        if (!success)
        {
            _toastNotification.AddErrorToastMessage("Error updating category.");
            return View(vm);
        }

        _toastNotification.AddSuccessToastMessage("Category updated successfully.");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _categoryService.DeleteAsync(id);
        if (!success)
        {
            _toastNotification.AddErrorToastMessage("Error deleting category.");
            return RedirectToAction("Index");
        }

        _toastNotification.AddSuccessToastMessage("Category deleted successfully.");
        return RedirectToAction("Index");
    }
}
