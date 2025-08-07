using InventoryMgmtSystem.Dto;
using InventoryMgmtSystem.Models;
using InventoryMgmtSystem.Repository.Interface;
using InventoryMgmtSystem.Services;
using InventoryMgmtSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMgmtSystem.Controllers
{
    public class StakeHolderController : Controller
    {
        private readonly IStakeHolderService _service;
        private readonly IStakeHolderRepository _repository;

        public StakeHolderController(IStakeHolderService service,IStakeHolderRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _repository.GetAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StakeHolderDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var vm = await _repository.GetByIdAsync(id);
            if (vm == null) return NotFound();

            var editVm = new StakeHolderEditVm
            {
                ID = vm.ID,
                Name = vm.Name,
                Address = vm.Address,
                Contact = vm.Contact,
                Email = vm.Email,
                Vat = vm.Vat,
                Type = vm.Type,
                IsActive = true 
            };

            return View(editVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StakeHolderEditVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            bool updated = await _service.UpdateAsync(vm);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
