using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class ProductUnitController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductUnitController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index(int? page = 1)
    {
        IEnumerable<ProductUnit> results = await _unitOfWork.ProductUnit.GetAll(page, inCludes: "Product,UnitType");
        return View(results);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductUnit productUnit)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.ProductUnit.Add(productUnit);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created productUnit";
            return RedirectToAction(nameof(Index));
        }
        return View(productUnit);
    }

    public async Task<IActionResult> Create()
    {
        IEnumerable<UnitType> results = await _unitOfWork.UnitType.GetAll();
        IEnumerable<SelectListItem> unitTypes = results.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewData["UnitTypeList"] = unitTypes;
        IEnumerable<Product> results1 = await _unitOfWork.Product.GetAll();
        IEnumerable<SelectListItem> Products = results1.Select(u => new SelectListItem
        {
            Text = u.Title,
            Value = u.Id.ToString()
        });
        ViewData["ProductList"] = Products;
        return View();
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productUnit = await _unitOfWork.ProductUnit.Get(b => b.Id == id, inCludes: "Product,UnitType");

        if (productUnit == null)
        {
            return NotFound();
        }

        return View(productUnit);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productUnit = await _unitOfWork.ProductUnit.Get(b => b.Id == id);
        if (productUnit == null)
        {
            return NotFound();
        }

        IEnumerable<UnitType> results = await _unitOfWork.UnitType.GetAll();
        IEnumerable<SelectListItem> unitTypes = results.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewData["UnitTypeList"] = unitTypes;
        IEnumerable<Product> results1 = await _unitOfWork.Product.GetAll();
        IEnumerable<SelectListItem> Products = results1.Select(u => new SelectListItem
        {
            Text = u.Title,
            Value = u.Id.ToString()
        });
        ViewData["ProductList"] = Products;

        return View(productUnit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductUnit productUnit)
    {
        if (id != productUnit.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.ProductUnit.Update(productUnit);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited productUnit";
            return RedirectToAction(nameof(Index));

        }
        return View(productUnit);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productUnit = await _unitOfWork.ProductUnit.Get(b => b.Id == id, inCludes: "Product,UnitType");
        if (productUnit == null)
        {
            return NotFound();
        }

        return View(productUnit);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var productUnit = await _unitOfWork.ProductUnit.Get(m => m.Id == id);
        if (productUnit != null)
        {
            _unitOfWork.ProductUnit.Remove(productUnit);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted productUnit";

        return RedirectToAction(nameof(Index));
    }

}