using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using MvcMovie.Repositories;


namespace MvcMovie.Controllers
{
    public class SaleController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Sale List Page (Index) - Display products
    public async Task<IActionResult> Index(string? searchString)
    {
        // Retrieve all products
        IEnumerable<Product> products = await _unitOfWork.Product.GetAll();

        // Filter products by search string if provided
        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
        }

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            // If this is an AJAX request, return only the product list HTML
            return PartialView("_ProductList", products);
        }

        // For non-AJAX requests, return the full view
        return View(products);
    }



        public async Task<IActionResult> OnSale(List<int> productIds)
        {
            if (productIds == null || !productIds.Any())
            {
                return RedirectToAction("Index"); // If no products selected, return to list
            }

            var products = (await _unitOfWork.Product.GetAll(p => productIds.Contains(p.Id))).ToList();


            var saleViewModel = new SaleViewModel
            {
                SelectedProducts = products.ToList()
            };

            // Fetch customer list for dropdown
            ViewBag.Customers = new SelectList(await _unitOfWork.Customer.GetAll(), "Id", "Name");

            return View(saleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmSale(SaleViewModel model, Dictionary<int, int> Quantities, Dictionary<int, double> UnitCosts, Dictionary<int, double> Discounts)
        {
            if (model.CustomerId == 0 || !Quantities.Any())
            {
                ModelState.AddModelError("", "Customer and at least one product must be selected.");
                return View("OnSale", model);
            }

            var sale = new Sale
            {
                CustomerId = model.CustomerId,
                SaleDate = DateTime.UtcNow,
                Deposit = model.Deposit
            };

            foreach (var productId in Quantities.Keys)
            {
                var saleDetail = new SaleDetail
                {
                    ProductId = productId,
                    Qty = Quantities[productId],
                    Discount = Discounts[productId]
                };

                sale.SaleDetails.Add(saleDetail);
            }

            _unitOfWork.Sale.Add(sale);
            _unitOfWork.save();

            return RedirectToAction("Index");
        }






        // Sale Processing (Sale Detail Page)
    //     public async Task<IActionResult> SaleProcessing()
    // {
    //     // Retrieve the selected product IDs from TempData
    //     var productIds = JsonSerializer.Deserialize<List<int>>(TempData["SelectedProducts"] as string);

    //     if (productIds == null || !productIds.Any())
    //     {
    //         return RedirectToAction("Index");
    //     }

    //     // Retrieve all products from the database
    //     var products = await _unitOfWork.Product.GetAll();

    //     // Filter the selected products based on the product IDs
    //     var selectedProducts = products.Where(p => productIds.Contains(p.Id)).ToList();

    //     if (!selectedProducts.Any())
    //     {
    //         return NotFound();
    //     }

    //     // Create the Sale model and set the selected products
    //     var sale = new Sale
    //     {
    //         ProductSaleDetails = selectedProducts.Select(p => new ProductSaleDetail
    //         {
    //             ProductId = p.Id,
    //             Product = p,
    //             Quantity = 1, // Default to 1
    //             UnitCost = p.Price, // Default unit cost as price
    //             Discount = 0, // Default discount is 0
    //             SupplierId = p.SupplierId // SupplierId from the product (if exists)
    //         }).ToList()
    //     };

    //     // Populate ViewData for the Supplier dropdown in the view
    //     ViewData["SupplierList"] = new SelectList(await _unitOfWork.Supplier.GetAll(), "Id", "Name");

    //     return View(sale); // Pass the Sale model to the view
    // }


    // Confirm Sale & Generate Invoice

    // [HttpPost]
    // public async Task<IActionResult> ConfirmSale(int supplierId, Dictionary<int, int> SupplierIds, 
    //                                             Dictionary<int, int> Quantities, Dictionary<int, double> UnitCosts, 
    //                                             Dictionary<int, double> Discounts, double Deposit)
    // {
    //     if (Quantities.Count != UnitCosts.Count || Quantities.Count != Discounts.Count || Quantities.Count != SupplierIds.Count)
    //     {
    //         ModelState.AddModelError("", "Product data is incomplete.");
    //         return RedirectToAction("SaleProcessing");
    //     }

    //     if (!(await _unitOfWork.Supplier.Exists(s => s.Id == supplierId)))
    //     {
    //         ModelState.AddModelError("", "Invalid Supplier. Please select a valid supplier.");
    //         return RedirectToAction("SaleProcessing");
    //     }

    //     var sale = new Sale
    //     {
    //         SupplierId = supplierId,
    //         Date = DateTime.Now,
    //         ProductSaleDetails = new List<ProductSaleDetail>(),
    //         Deposit = Deposit
    //     };

    //     foreach (var productId in SupplierIds.Keys)
    //     {
    //         var product = await _unitOfWork.Product.Get(p => p.Id == productId);
    //         if (product != null)
    //         {
    //             sale.ProductSaleDetails.Add(new ProductSaleDetail
    //             {
    //                 ProductId = productId,
    //                 Product = product,
    //                 Quantity = Quantities[productId],
    //                 UnitCost = UnitCosts[productId],
    //                 Discount = Discounts[productId],
    //                 SupplierId = SupplierIds[productId]
    //             });
    //         }
    //     }

    //     _unitOfWork.Sale.Add(sale);
    //     _unitOfWork.save();

    //     // ✅ Redirect to the Invoice page after saving the sale
    //     return RedirectToAction("Invoice", new { id = sale.Id });
    // }



    public async Task<IActionResult> Invoice(int saleId)
    {
        var sale = await _unitOfWork.Sale.Get(s => s.Id == saleId, inCludes: "ProductSaleDetails.Product,Supplier");
        if (sale == null)
        {
            return NotFound();
        }

        return View(sale);
    }




}
    


}
