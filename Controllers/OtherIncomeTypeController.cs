using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;
using X.PagedList;

namespace MvcMovie.Controllers;

public class OtherIncomeTypeController : Controller
{
    private readonly ILogger<OtherIncomeTypeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public OtherIncomeTypeController(ILogger<OtherIncomeTypeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? page = 1)
    {
        IPagedList<OtherIncomeType> pagedList = await _unitOfWork.OtherIncomeType.GetAll(page);
        return View(pagedList);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OtherIncomeType otherIncomeType)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.OtherIncomeType.Add(otherIncomeType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created otherIncomeType";
            return RedirectToAction(nameof(Index));
        }
        return View(otherIncomeType);
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

        var otherIncomeType = await _unitOfWork.OtherIncomeType
            .Get(b => b.Id == id);

        if (otherIncomeType == null)
        {
            return NotFound();
        }

        return View(otherIncomeType);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var otherIncomeType = await _unitOfWork.OtherIncomeType.Get(b => b.Id == id);
        if (otherIncomeType == null)
        {
            return NotFound();
        }

        return View(otherIncomeType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, OtherIncomeType otherIncomeType)
    {
        if (id != otherIncomeType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.OtherIncomeType.Update(otherIncomeType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited otherIncomeType";
            return RedirectToAction(nameof(Index));

        }
        return View(otherIncomeType);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var otherIncomeType = await _unitOfWork.OtherIncomeType.Get
            (m => m.Id == id);
        if (otherIncomeType == null)
        {
            return NotFound();
        }

        return View(otherIncomeType);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var otherIncomeType = await _unitOfWork.OtherIncomeType.Get(m => m.Id == id);
        if (otherIncomeType != null)
        {
            _unitOfWork.OtherIncomeType.Remove(otherIncomeType);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted otherIncomeType";

        return RedirectToAction(nameof(Index));
    }
}