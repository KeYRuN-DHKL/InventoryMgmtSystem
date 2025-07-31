using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Entity;
using InventoryMgmtSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace InventoryMgmtSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;

        public ProductController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Unit).ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = vm.Name,
                    Description = vm.Description,
                    UnitId = vm.UnitId
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Product created successfully");
                return RedirectToAction("Index");
            }
            catch (Exception e){
                return View(vm);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _toastNotification.AddAlertToastMessage("Product not found");
                    return RedirectToAction("Index");
                }

                var vm = new ProductEditVm
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    UnitId = product.UnitId
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
        public async Task<IActionResult> Edit(ProductEditVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Units = new SelectList(_context.Units.ToList(), "Id", "FullName", vm.UnitId);
                    return View(vm);
                }

                var product = await _context.Products.FindAsync(vm.Id);
                if (product == null)
                {
                    _toastNotification.AddAlertToastMessage("Product Not Found");
                    return RedirectToAction("Index");
                }

                product.Name = vm.Name;
                product.Description = vm.Description;
                product.IsActive = vm.IsActive;
                product.UnitId = vm.UnitId;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Product Updated Successfully");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _toastNotification.AddErrorToastMessage("Product not found.");
                    return RedirectToAction("Index");
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Product deleted successfully.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage("Error deleting product: " + ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
