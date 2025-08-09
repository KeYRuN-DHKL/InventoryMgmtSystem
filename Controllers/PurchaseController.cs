using System.Runtime.InteropServices.JavaScript;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Enums;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using InventoryMgmtSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMgmtSystem.Controllers;

public class PurchaseController : Controller
{
    // GET
    private readonly IStakeHolderRepository _stakeHolderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPurchaseService _purchaseService;
    private readonly IStockMovementService _stockMovementServicec;


    public PurchaseController(IStakeHolderRepository stakeHolderRepository, IProductRepository productRepository, IPurchaseService purchaseService, IStockMovementService stockMovementServicec)
    {
        _stakeHolderRepository = stakeHolderRepository;
        _productRepository = productRepository;
        _purchaseService = purchaseService;
        _stockMovementServicec = stockMovementServicec;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            var vm = new PurchaseVm()
            {
                StockMovement = new List<StockMovementVm>()
                {
                    new StockMovementVm()
                }
            };
            
            vm.StakeHolders = await _stakeHolderRepository.GetStakeHolderList();
            vm.Products = await _productRepository.GetProductList();
            vm.Tdate = DateOnly.FromDateTime(DateTime.UtcNow);
            return View(vm);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseVm vm)
    {
        try
        {
            if (!ModelState.IsValid)
            {


                vm.StockMovement = new List<StockMovementVm>()
                {
                    new StockMovementVm()
                };
            
                vm.StakeHolders = await _stakeHolderRepository.GetStakeHolderList();
                vm.Products = await _productRepository.GetProductList();
                vm.Tdate = DateOnly.FromDateTime(DateTime.UtcNow);
                return View(vm);
                
            }

            var dto = new PurchaseDto()
            {
                Amount = vm.Amount,
                Tdate = vm.Tdate,
                Remark = vm.Remark,
                InvoiceNo = vm.InvoiceNo,
                TaxAmount = vm.TaxAmount,
                TaxableAmount = vm.TaxableAmount,
                StakeHolderId = vm.StakeHolderId
            };
            var purchase = await _purchaseService.Create(dto);
            var stockmovementDto = vm.StockMovement.Select(item => new StockMovementDto
            {
                Quantity = item.Quantity,
                Rate = item.Rate,
                Stock = Stock.In,
                Type = MovementType.Purchase,
                ProductId = item.ProductId,
                TypeId = purchase.Id,
                VatPer = item.VatPer
            }).ToList();
            await _stockMovementServicec.Create(stockmovementDto);
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return RedirectToAction("Index");
        }
        
    }

}