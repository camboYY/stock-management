using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class BranchController : Controller
{
    private readonly ILogger<BranchController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BranchController(ILogger<BranchController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Branch> branches = await _unitOfWork.Branch.GetAll();
        return View(branches);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Branch branch)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Branch.Add(branch);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created branch";
            return RedirectToAction(nameof(Index));
        }
        return View(branch);
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

        var branch = await _unitOfWork.Branch
            .Get(b => b.Id == id);

        if (branch == null)
        {
            return NotFound();
        }

        return View(branch);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var branch = await _unitOfWork.Branch.Get(b => b.Id == id);
        if (branch == null)
        {
            return NotFound();
        }

        return View(branch);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Branch branch)
    {
        if (id != branch.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Branch.Update(branch);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited branch";
            return RedirectToAction(nameof(Index));

        }
        return View(branch);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var branch = await _unitOfWork.Branch.Get
            (m => m.Id == id);
        if (branch == null)
        {
            return NotFound();
        }

        return View(branch);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var branch = await _unitOfWork.Branch.Get(m => m.Id == id);
        if (branch != null)
        {
            _unitOfWork.Branch.Remove(branch);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted branch";

        return RedirectToAction(nameof(Index));
    }
}