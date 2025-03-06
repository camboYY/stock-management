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
    }

}