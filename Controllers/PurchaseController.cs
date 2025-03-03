using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using MvcMovie.Repositories;
using MvcMovie.Utility;
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

        // Retrieve and deserialize the stored data
        if (TempData["SelectedItems"] != null)
        {

            IEnumerable<UnitType> result = await _unitOfWork.UnitType.GetAll();
            IEnumerable<SelectListItem> unitTypes = result.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["UnitTypeList"] = unitTypes;

            IEnumerable<Supplier> results = await _unitOfWork.Supplier.GetAll();
            IEnumerable<SelectListItem> Supplier = results.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["SupplierList"] = Supplier;

            var selectedItems = JsonSerializer.Deserialize<List<string>>(
                TempData["SelectedItems"].ToString());

            List<Product> products = await _unitOfWork.Product.GetList(p => selectedItems!.Contains(p.Id.ToString()), inCludes: "Supplier");

            return View(products);
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> OnConfirmPurchase()
    {
        using (var reader = new StreamReader(Request.Body))
        {
            var json = await reader.ReadToEndAsync();
            OnPurchasing purchase = JsonSerializer.Deserialize<OnPurchasing>(json);

            if (purchase == null)
            {
                return Json(new { redirectUrl = Url.Action("Purchasing", "Purchase") });
            }
            else
            {
                using (var transaction = _unitOfWork._db.Database.BeginTransaction())
                {
                    try
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get User ID

                        var newPurchase = new Purchase { PurchaseOrderNumber = GenerateTimestampNumber(), PurchaseDate = DateTime.Today, Date = DateTime.Now, UserId1 = userId, SupplierId = purchase.sum.SupplierId, Amount = purchase.sum.sumTotal, Deposit = purchase.sum.sumDeposit, Discount = purchase.sum.sumDiscount, Status = false };
                        _unitOfWork.Purchase.Add(newPurchase);
                        _unitOfWork.save();

                        var purchaseDetail = new List<PurchaseDetail> { };

                        foreach (ConfirmPurchase confirmPurchase in purchase.list)
                        {
                            purchaseDetail.Add(new PurchaseDetail
                            {
                                PurchaseId = newPurchase.Id,
                                ProductId = confirmPurchase.ProductId,
                                Cost = confirmPurchase.Cost,
                                Discount = confirmPurchase.Discount,
                                Qty = confirmPurchase.Unit,
                                UnitTypeId = confirmPurchase.UnitTypeId
                            });
                        }

                        _unitOfWork.PurchaseDetail.AddRange(purchaseDetail);
                        _unitOfWork.save(); // Save changes

                        transaction.Commit(); // Commit transaction
                        TempData["success"] = "You have successfully purchased items";
                        return Json(new { redirectUrl = Url.Action("Payment", "Purchase") });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Rollback transaction on error
                        return Content("Error: " + ex.Message);
                    }
                }
            }

        }

    }

    [HttpGet]
    public async Task<IActionResult> Payment(int? page = 1)
    {
        IEnumerable<Purchase> purchases = await _unitOfWork.Purchase.GetAll(page, inCludes: "Supplier,User");
        return View(purchases);
    }

    public async Task<IActionResult> Details(int Id)
    {
        IEnumerable<PurchaseDetail>? filteredPurcahses = null;
        IPagedList<PurchaseDetail> purchaseDetails = await _unitOfWork.PurchaseDetail.GetAll(inCludes: "Purchase,UnitType,Product");
        filteredPurcahses = purchaseDetails.ToList().Where(s => s.Id == Id);
        return View(filteredPurcahses);
    }

    public async Task<IActionResult> CreatePurchasePayment(int Id)
    {

        IEnumerable<PaymentMethod> results = await _unitOfWork.PaymentMethod.GetAll();
        IEnumerable<SelectListItem> paymentOpts = results.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewData["PaymentOption"] = paymentOpts;

        IEnumerable<Purchase> purchases = await _unitOfWork.Purchase.GetAll();
        IEnumerable<SelectListItem> purchaseList = purchases.Select(u => new SelectListItem
        {
            Text = u.PurchaseOrderNumber.ToString(),
            Value = u.Id.ToString()
        });

        ViewData["PurchaseList"] = purchaseList;

        var foundResult = await _unitOfWork.Purchase.Get(p => p.Id == Id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get User ID

        // Create and populate the ViewModel
        var viewModel = new PaymentPurchase

        {
            UserId = userId,
            PurchaseId = foundResult.Id,
            PaymentMethodId = 1,
            PayDate = DateTime.Now,
            PayAmount = foundResult.Amount
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Paying(PurchasePayment purchasePayment)
    {

        using (var transaction = _unitOfWork._db.Database.BeginTransaction())
        {
            try
            {

                _unitOfWork.PurchasePayment.Add(purchasePayment);
                _unitOfWork.save(); // Save changes
                Purchase entity = await _unitOfWork.Purchase.Get(purchase => purchase.Id == purchasePayment.PurchaseId);


                if (entity == null)
                {
                    return NotFound();
                }
                entity.Status = true;
                _unitOfWork.Purchase.Update(entity);
                _unitOfWork.save(); // Save changes

                TempData["success"] = "You have successfully paid";

                transaction.Commit(); // Commit transaction

            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

        return RedirectToAction(nameof(Payment));

    }


    private long GenerateTimestampNumber()
    {
        return long.Parse(DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")); // Example: 20250224123045001
    }

}