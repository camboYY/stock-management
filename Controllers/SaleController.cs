using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using MvcMovie.Repositories;
using MvcMovie.Utility;
using X.PagedList;

namespace MvcMovie.Controllers;

public class SaleController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleController(IUnitOfWork unitOfWork)
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
    public async Task<IActionResult> OnSale()
    {
        using (var reader = new StreamReader(Request.Body))
        {
            var json = await reader.ReadToEndAsync();
            List<string> values = JsonSerializer.Deserialize<List<string>>(json);

            if (values == null || values.Count == 0)
            {
                return Json(new { redirectUrl = Url.Action("Saling", "Sale") });
            }
            else
            {
                TempData["SelectedItems"] = JsonSerializer.Serialize(values);
                return Json(new { redirectUrl = Url.Action("Saling", "Sale") });
            }

        }

    }

    public async Task<IActionResult> Saling()
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

            IEnumerable<Customer> results = await _unitOfWork.Customer.GetAll();
            IEnumerable<SelectListItem> customer = results.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["CustomerList"] = customer;


            IEnumerable<Rate> rate = await _unitOfWork.Rate.GetAll(1);
            IEnumerable<SelectListItem> rates = rate.Select(u => new SelectListItem
            {
                Text = u.Date.ToString(),
                Value = u.Id.ToString()
            });
            ViewData["RateList"] = rates;

            var selectedItems = JsonSerializer.Deserialize<List<string>>(
                TempData["SelectedItems"].ToString());

            List<Product> products = await _unitOfWork.Product.GetList(p => selectedItems!.Contains(p.Id.ToString()));

            return View(products);
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> OnConfirmSale()
    {
        using (var reader = new StreamReader(Request.Body))
        {
            var json = await reader.ReadToEndAsync();
            OnSaling saling = JsonSerializer.Deserialize<OnSaling>(json);

            if (saling == null)
            {
                return Json(new { redirectUrl = Url.Action("Saling", "Sale") });
            }
            else
            {
                using (var transaction = _unitOfWork._db.Database.BeginTransaction())
                {
                    try
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get User ID

                        var newSale = new Sale
                        {
                            InvoiceNumber = GenerateTimestampNumber(),
                            SaleDate = saling.sum.SaleDate,
                            Date = DateTime.Now,
                            PreparedBy = userId,
                            CustomerId = saling.sum.CustomerId,
                            Amount = saling.sum.sumTotal,
                            Deposit = saling.sum.sumDeposit,
                            Discount = saling.sum.sumDiscount,
                            Status = saling.sum.Status,
                            RateId = saling.sum.RateId
                        };

                        _unitOfWork.Sale.Add(newSale);
                        _unitOfWork.save();

                        var saleDetails = new List<SaleDetail>();

                        foreach (ConfirmSale confirmSale in saling.list)
                        {
                            var productUnit = await _unitOfWork.ProductUnit.Get(p => p.ProductId == confirmSale.ProductId);
                            saleDetails.Add(new SaleDetail
                            {
                                SaleId = newSale.Id,
                                ProductId = confirmSale.ProductId,
                                Cost = productUnit.Cost,
                                Discount = confirmSale.Discount,
                                Qty = confirmSale.Unit,
                                UnitTypeId = confirmSale.UnitTypeId,
                                Price = confirmSale.Price
                            });
                            var item = await _unitOfWork.Product.Get(p => p.Id == confirmSale.ProductId);
                            if (item != null)
                            {
                                // Ensure consistent use of decimal for financial calculations
                                if (item.QtyOnHand > 0) // First Purchase
                                {
                                    item.QtyOnHand = item.QtyOnHand - confirmSale.Unit;
                                }
                                else
                                {
                                    TempData["error"] = "An item : " + item.Title + " is out of stock.";
                                    throw new Exception("Product : " + item.Title + " out of stock");
                                }

                                _unitOfWork.Product.Update(item);
                                _unitOfWork.save();
                            }
                        }

                        _unitOfWork.SaleDetail.AddRange(saleDetails);
                        _unitOfWork.save(); // Save changes

                        transaction.Commit(); // Commit transaction
                        TempData["success"] = "You have successfully sold items";
                        return Json(new { redirectUrl = Url.Action("Payment", "Sale") });
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
        IEnumerable<Sale> sales = await _unitOfWork.Sale.GetAll(page, inCludes: "Customer,ApplicationUser");
        return View(sales);
    }

    public async Task<IActionResult> Details(int Id)
    {
        IEnumerable<SaleDetail>? filteredSales = null;
        IPagedList<SaleDetail> saleDetails = await _unitOfWork.SaleDetail.GetAll(inCludes: "Sale,UnitType,Product");
        filteredSales = saleDetails.ToList().Where(s => s.SaleId == Id);
        return View(filteredSales);
    }

    public async Task<IActionResult> CreateSalePayment(int Id)
    {

        IEnumerable<PaymentMethod> results = await _unitOfWork.PaymentMethod.GetAll();
        IEnumerable<SelectListItem> paymentOpts = results.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewData["PaymentOption"] = paymentOpts;

        IEnumerable<Sale> sales = await _unitOfWork.Sale.GetAll();
        IEnumerable<SelectListItem> saleList = sales.Select(u => new SelectListItem
        {
            Text = u.InvoiceNumber.ToString(),
            Value = u.Id.ToString()
        });

        ViewData["SaleList"] = saleList;

        var foundResult = await _unitOfWork.Sale.Get(p => p.Id == Id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get User ID

        // Create and populate the ViewModel
        var viewModel = new PaymentSale

        {
            UserId = userId,
            SaleId = foundResult.Id,
            PaymentMethodId = 1,
            PayDate = DateTime.Now,
            PayAmount = foundResult.Amount
        };

        return View(viewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Paying(SalePayment salePayment)
    {

        using (var transaction = _unitOfWork._db.Database.BeginTransaction())
        {
            try
            {

                _unitOfWork.SalePayment.Add(salePayment);
                _unitOfWork.save(); // Save changes
                Sale entity = await _unitOfWork.Sale.Get(s => s.Id == salePayment.SaleId);


                if (entity == null)
                {
                    return NotFound();
                }
                entity.Status = true;
                _unitOfWork.Sale.Update(entity);
                _unitOfWork.save(); // Save changes

                TempData["success"] = "You have successfully paid";

                transaction.Commit(); // Commit transaction

            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Rollback transaction on error
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
