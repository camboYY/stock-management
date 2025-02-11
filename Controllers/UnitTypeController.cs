using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class UnitTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UnitTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<UnitType> results = await _unitOfWork.UnitType.GetAll();
        return View(results);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UnitType unitType)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.UnitType.Add(unitType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created unitType";
            return RedirectToAction(nameof(Index));
        }
        return View(unitType);
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

        var unitType = await _unitOfWork.UnitType
            .Get(b => b.Id == id);

        if (unitType == null)
        {
            return NotFound();
        }

        return View(unitType);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var unitType = await _unitOfWork.UnitType.Get(b => b.Id == id);
        if (unitType == null)
        {
            return NotFound();
        }

        return View(unitType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UnitType unitType)
    {
        if (id != unitType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.UnitType.Update(unitType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited unitType";
            return RedirectToAction(nameof(Index));

        }
        return View(unitType);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var unitType = await _unitOfWork.UnitType.Get
            (m => m.Id == id);
        if (unitType == null)
        {
            return NotFound();
        }

        return View(unitType);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var unitType = await _unitOfWork.UnitType.Get(m => m.Id == id);
        if (unitType != null)
        {
            _unitOfWork.UnitType.Remove(unitType);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted unitType";

        return RedirectToAction(nameof(Index));
    }

}