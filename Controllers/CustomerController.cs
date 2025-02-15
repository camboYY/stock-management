using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;
using X.PagedList;

namespace MvcMovie.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CustomerController(ILogger<CustomerController> logger, IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index(int? page = 1)
    {
        IPagedList<Customer> pagedList = await _unitOfWork.Customer.GetAll(page);
        return View(pagedList);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer customer, IFormFile? file)
    {
        if (ModelState.IsValid)
        {

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images/customer");

                if (!string.IsNullOrEmpty(customer.Image))
                {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, customer.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                customer.Image = @"/images/customer/" + fileName;
            }
            _unitOfWork.Customer.Add(customer);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created customer";
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
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

        var customer = await _unitOfWork.Customer
            .Get(b => b.Id == id);

        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = await _unitOfWork.Customer.Get(b => b.Id == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Customer customer, string? ImageUrl, IFormFile? file)
    {
        if (id != customer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images/customer");

                if (!string.IsNullOrEmpty(customer.Image))
                {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, customer.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                customer.Image = @"/images/customer/" + fileName;
            }
            else
            {
                customer.Image = ImageUrl;

            }
            _unitOfWork.Customer.Update(customer);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited customer";
            return RedirectToAction(nameof(Index));

        }
        return View(customer);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = await _unitOfWork.Customer.Get
            (m => m.Id == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var customer = await _unitOfWork.Customer.Get(m => m.Id == id);
        if (customer != null)
        {
            _unitOfWork.Customer.Remove(customer);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted customer";

        return RedirectToAction(nameof(Index));
    }
}