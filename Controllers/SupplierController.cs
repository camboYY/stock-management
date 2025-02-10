using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class SupplierController : Controller
{
    private readonly ILogger<SupplierController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierController(ILogger<SupplierController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Supplier> results = await _unitOfWork.Supplier.GetAll();
        return View(results);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Supplier.Add(supplier);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created supplier";
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
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

        var supplier = await _unitOfWork.Supplier
            .Get(b => b.Id == id);

        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = await _unitOfWork.Supplier.Get(b => b.Id == id);
        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Supplier supplier)
    {
        if (id != supplier.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Supplier.Update(supplier);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited supplier";
            return RedirectToAction(nameof(Index));

        }
        return View(supplier);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = await _unitOfWork.Supplier.Get
            (m => m.Id == id);
        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var supplier = await _unitOfWork.Supplier.Get(m => m.Id == id);
        if (supplier != null)
        {
            _unitOfWork.Supplier.Remove(supplier);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted supplier";

        return RedirectToAction(nameof(Index));
    }
}