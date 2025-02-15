using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public class PaymentMethodController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentMethodController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? page = 1)
    {
        IEnumerable<PaymentMethod> branches = await _unitOfWork.PaymentMethod.GetAll(page);
        return View(branches);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaymentMethod paymentMethod)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.PaymentMethod.Add(paymentMethod);
            _unitOfWork.save();
            TempData["success"] = "You have successfully created paymentMethod";
            return RedirectToAction(nameof(Index));
        }
        return View(paymentMethod);
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

        var paymentMethod = await _unitOfWork.PaymentMethod
            .Get(b => b.Id == id);

        if (paymentMethod == null)
        {
            return NotFound();
        }

        return View(paymentMethod);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paymentMethod = await _unitOfWork.PaymentMethod.Get(b => b.Id == id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        return View(paymentMethod);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PaymentMethod paymentMethod)
    {
        if (id != paymentMethod.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.PaymentMethod.Update(paymentMethod);
            _unitOfWork.save();
            TempData["success"] = "You have successfully edited paymentMethod";
            return RedirectToAction(nameof(Index));

        }
        return View(paymentMethod);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paymentMethod = await _unitOfWork.PaymentMethod.Get
            (m => m.Id == id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        return View(paymentMethod);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var paymentMethod = await _unitOfWork.PaymentMethod.Get(m => m.Id == id);
        if (paymentMethod != null)
        {
            _unitOfWork.PaymentMethod.Remove(paymentMethod);
        }

        _unitOfWork.save();
        TempData["success"] = "You have successfully deleted paymentMethod";

        return RedirectToAction(nameof(Index));
    }

}