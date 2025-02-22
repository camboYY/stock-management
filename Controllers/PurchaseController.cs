using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using MvcMovie.Repositories;
using X.PagedList;

namespace MvcMovie.Controllers;

public class PurchaseController : Controller
{
    private IUnitOfWork _unitOfWork;

    public PurchaseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(string? searchString)
    {
        IEnumerable<Product>? filteredProducts = null;
        IPagedList<Product> products = await _unitOfWork.Product.GetAll(inCludes: "Category");
        filteredProducts = products.ToList();
        if (!string.IsNullOrEmpty(searchString))
        {
            filteredProducts = products.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
        }
        return View(filteredProducts);
    }

    [HttpPost]
    public async Task<IActionResult> OnPurchase()
    {
        using (var reader = new StreamReader(Request.Body))
        {
            var json = await reader.ReadToEndAsync();
            List<string> values = JsonSerializer.Deserialize<List<string>>(json);

            if (values == null || values.Count == 0)
            {
                return Json(new { redirectUrl = Url.Action("Purchasing", "Purchase") });
            }
            else
            {
                TempData["SelectedItems"] = JsonSerializer.Serialize(values);
                return Json(new { redirectUrl = Url.Action("Purchasing", "Purchase") });
            }

        }

    }

    [HttpGet]
    public async Task<IActionResult> Purchasing()
    {
        IEnumerable<Warehouse> warehouses = await _unitOfWork.Warehouse.GetAll();
        IEnumerable<SelectListItem> warehouselist = warehouses.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });

        ViewData["WarehouseList"] = warehouselist;

        IEnumerable<Supplier> suppliers = await _unitOfWork.Supplier.GetAll();
        IEnumerable<SelectListItem> supplierList = suppliers.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });

        ViewData["SupplierList"] = supplierList;

        IEnumerable<Branch> branches = await _unitOfWork.Branch.GetAll();
        IEnumerable<SelectListItem> branchList = branches.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });

        ViewData["BranchList"] = branchList;

        // Retrieve and deserialize the stored data
        if (TempData["SelectedItems"] != null)
        {
            var selectedItems = JsonSerializer.Deserialize<List<string>>(
                TempData["SelectedItems"].ToString());

            List<Product> products = await _unitOfWork.Product.GetList(p => selectedItems!.Contains(p.Id.ToString()));

            return View(products);
        }

        return View();
    }
}