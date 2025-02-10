using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class WarehouseController : Controller
{
    private readonly ILogger<WarehouseController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public WarehouseController(ILogger<WarehouseController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Warehouse> branches = await _unitOfWork.Warehouse.GetAll();
        return View(branches);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Warehouse warehouse)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Warehouse.Add(warehouse);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created warehouse";
            return RedirectToAction(nameof(Index));
        }
        return View(warehouse);
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var warehouse = await _unitOfWork.Warehouse
            .Get(b => b.Id == id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var warehouse = await _unitOfWork.Warehouse.Get(b => b.Id == id);
        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Warehouse warehouse)
    {
        if (id != warehouse.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Warehouse.Update(warehouse);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited warehouse";
            return RedirectToAction(nameof(Index));

        }
        return View(warehouse);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var warehouse = await _unitOfWork.Warehouse.Get
            (m => m.Id == id);
        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var warehouse = await _unitOfWork.Warehouse.Get(m => m.Id == id);
        if (warehouse != null)
        {
            _unitOfWork.Warehouse.Remove(warehouse);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted warehouse";

        return RedirectToAction(nameof(Index));
    }
}