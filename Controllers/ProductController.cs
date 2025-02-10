using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Repositories;
using MvcMovie.Utility;

namespace MvcMovie.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Product.GetAll(inCludes: "Category,Branch,Supplier,Warehouse"));
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product
                .Get(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            var categoryList = await _unitOfWork.Category.GetAll();
            IEnumerable<SelectListItem> categories = categoryList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(product);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var categoryList = await _unitOfWork.Category.GetAll();
            IEnumerable<SelectListItem> categories = categoryList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.categoryList = categories;

            var WarehouseList = await _unitOfWork.Warehouse.GetAll();
            IEnumerable<SelectListItem> warehouses = WarehouseList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["WarehouseList"] = warehouses;

            var BranchList = await _unitOfWork.Branch.GetAll();
            IEnumerable<SelectListItem> branches = BranchList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["BranchList"] = branches;

            var SupplierList = await _unitOfWork.Supplier.GetAll();
            IEnumerable<SelectListItem> suppliers = SupplierList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["SupplierList"] = suppliers;

            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    if (!string.IsNullOrEmpty(product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.ImageUrl = @"/images/product/" + fileName;
                }

                if (string.IsNullOrEmpty(product.ImageUrl))
                {
                    product.ImageUrl = "default.jpg"; // Assign a default image URL
                }
                _unitOfWork.Product.Add(product);
                _unitOfWork.save();
                TempData["success"] = "You have successfully created product";

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product.Get(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var categoryList = await _unitOfWork.Category.GetAll();
            IEnumerable<SelectListItem> categories = categoryList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.categoryList = categories;

            var WarehouseList = await _unitOfWork.Warehouse.GetAll();
            IEnumerable<SelectListItem> warehouses = WarehouseList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["WarehouseList"] = warehouses;

            var BranchList = await _unitOfWork.Branch.GetAll();
            IEnumerable<SelectListItem> branches = BranchList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["BranchList"] = branches;

            var SupplierList = await _unitOfWork.Supplier.GetAll();
            IEnumerable<SelectListItem> suppliers = SupplierList.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["SupplierList"] = suppliers;

            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string? ImageUrl, Product product, IFormFile? file)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"images/product");

                        if (!string.IsNullOrEmpty(product.ImageUrl))
                        {
                            //delete the old image
                            var oldImagePath =
                                Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        product.ImageUrl = @"/images/product/" + fileName;
                    }
                    else
                    {
                        product.ImageUrl = ImageUrl;
                    }
                    _unitOfWork.Product.Update(product);
                    _unitOfWork.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MovieExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "You have successfully edited product";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product.Get
                (m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _unitOfWork.Product.Get(m => m.Id == id);
            if (product != null)
            {
                _unitOfWork.Product.Remove(product);
            }

            _unitOfWork.save();
            TempData["success"] = "You have successfully deleted product";

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MovieExists(int id)
        {
            var product = await _unitOfWork.Product.Get(e => e.Id == id);
            return product != null;
        }

    }

}