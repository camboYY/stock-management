using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Repositories;
using MvcMovie.Utility;
using X.PagedList;

namespace MvcMovie.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductReportController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> ProductInStock(int? page = 1)
        {
            var productsList = await _unitOfWork.Product.GetAll(inCludes: "Category,Branch,Supplier,Warehouse");
            var filteredProducts = productsList.Where(p => p.QtyOnHand > 0);
            IPagedList<Product> products = new StaticPagedList<Product>(filteredProducts, page ?? 1, 10, filteredProducts.Count());
            return View(products);
        }

        public async Task<IActionResult> ProductOutOfStock(int? page = 1)
        {
            var productsList = await _unitOfWork.Product.GetAll(inCludes: "Category,Branch,Supplier,Warehouse");
            var filteredProducts = productsList.Where(p => p.QtyOnHand <= 0);
            IPagedList<Product> products = new StaticPagedList<Product>(filteredProducts, page ?? 1, 10, filteredProducts.Count());
            return View(products);
        }
        public async Task<IActionResult> ProductQtyAlert(int? page = 1)
        {
            var productsList = await _unitOfWork.Product.GetAll(inCludes: "Category,Branch,Supplier,Warehouse");
            var filteredProducts = productsList.Where(p => p.QtyOnHand <= p.QtyAlert);
            IPagedList<Product> products = new StaticPagedList<Product>(filteredProducts, page ?? 1, 10, filteredProducts.Count());
            return View(products);
        }
        public async Task<IActionResult> ProductTopSold(int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var saleDetails = await _unitOfWork.SaleDetail.GetAll(inCludes: "Product");

            var topSoldProducts = saleDetails
                .GroupBy(sd => sd.Product)
                .Select(group => new ProductTopSoldViewModel
                {
                    Product = group.Key,
                    TotalSold = group.Sum(sd => sd.Qty)  // Summing up sold quantities
                })
                .OrderByDescending(p => p.TotalSold)
                .ToList();

            IPagedList<ProductTopSoldViewModel> pagedProducts = new StaticPagedList<ProductTopSoldViewModel>(
                topSoldProducts, pageNumber, pageSize, topSoldProducts.Count
            );

            return View(pagedProducts);
        }
    }

}