using System.Runtime.InteropServices.JavaScript;
using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Enums;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using InventoryMgmtSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMgmtSystem.Controllers;

public class SalesController : Controller
{
    // GET
    private readonly IStakeHolderRepository _stakeHolderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISalesService _salesService;
    private readonly IStockMovementService _stockMovementServicec;


    public SalesController(IStakeHolderRepository stakeHolderRepository, IProductRepository productRepository, ISalesService salesService, IStockMovementService stockMovementServicec)
    {
        _stakeHolderRepository = stakeHolderRepository;
        _productRepository = productRepository;
        _salesService = salesService;
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
            var vm = new SalesVm()
            {
                StockMovement = new List<StockMovementVm>()
                {
                    new StockMovementVm()
                }
            };
            vm.InvoiceNo = await _salesService.CreateInvoiceNumber();
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
    public async Task<IActionResult> Create(SalesVm vm)
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

            var dto = new SaleDto()
            {
                Amount = vm.Amount,
                Tdate = vm.Tdate,
                Remark = vm.Remark,
                InvoiceNo = vm.InvoiceNo,
                TaxAmount = vm.TaxAmount,
                TaxableAmount = vm.TaxableAmount,
                StakeHolderId = vm.StakeHolderId
            };
            var sales = await _salesService.Create(dto);
            var stockmovementDto = vm.StockMovement.Select(item => new StockMovementDto
            {
                Quantity = item.Quantity,
                Rate = item.Rate,
                Stock = Stock.Out,
                Type = MovementType.Sales,
                ProductId = item.ProductId,
                TypeId = sales.Id,
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
