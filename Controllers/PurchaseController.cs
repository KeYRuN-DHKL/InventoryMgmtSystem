using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMgmtSystem.Controllers;

public class PurchaseController : Controller
{
    // GET
    public readonly IStakeHolderRepository _stakeHolderRepository;
    public readonly IProductRepository _productRepository;

    public PurchaseController(IStakeHolderRepository stakeHolderRepository, IProductRepository productRepository)
    {
        _stakeHolderRepository = stakeHolderRepository;
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            var vm = new PurchaseVm();
            vm.StakeHolders = await _stakeHolderRepository.GetStakeHolderList();
            vm.Products = await _productRepository.GetProductList();
            return View(vm);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return RedirectToAction("Index");
        }
    }
}