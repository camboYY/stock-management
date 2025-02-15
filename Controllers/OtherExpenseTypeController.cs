using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;
using X.PagedList;

namespace MvcMovie.Controllers;

public class OtherExpenseTypeController : Controller
{
    private readonly ILogger<OtherExpenseTypeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public OtherExpenseTypeController(ILogger<OtherExpenseTypeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? page)
    {

        IPagedList<OtherExpenseType> results = await _unitOfWork.OtherExpenseType.GetAll(page);

        return View(results);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OtherExpenseType otherExpenseType)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.OtherExpenseType.Add(otherExpenseType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created otherExpenseType";
            return RedirectToAction(nameof(Index));
        }
        return View(otherExpenseType);
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

        var otherExpenseType = await _unitOfWork.OtherExpenseType
            .Get(b => b.Id == id);

        if (otherExpenseType == null)
        {
            return NotFound();
        }

        return View(otherExpenseType);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var otherExpenseType = await _unitOfWork.OtherExpenseType.Get(b => b.Id == id);
        if (otherExpenseType == null)
        {
            return NotFound();
        }

        return View(otherExpenseType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, OtherExpenseType otherExpenseType)
    {
        if (id != otherExpenseType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.OtherExpenseType.Update(otherExpenseType);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited otherExpenseType";
            return RedirectToAction(nameof(Index));

        }
        return View(otherExpenseType);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var otherExpenseType = await _unitOfWork.OtherExpenseType.Get
            (m => m.Id == id);
        if (otherExpenseType == null)
        {
            return NotFound();
        }

        return View(otherExpenseType);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var otherExpenseType = await _unitOfWork.OtherExpenseType.Get(m => m.Id == id);
        if (otherExpenseType != null)
        {
            _unitOfWork.OtherExpenseType.Remove(otherExpenseType);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted otherExpenseType";

        return RedirectToAction(nameof(Index));
    }
}