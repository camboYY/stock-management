using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RateController : Controller
    {
        private readonly ILogger<RateController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RateController(ILogger<RateController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: Rate
        public async Task<IActionResult> Index(int? page = 1)
        {
            // Default page if not provided
            if (page == null || page <= 0)
            {
                page = 1;
            }

            // Call the GetAll method in the repository
            var rates = await _unitOfWork.Rate.GetAll(page);

            // Check if rates are null or empty
            if (rates == null || !rates.Any())
            {
                TempData["error"] = "No rates found.";
                return View(new List<Rate>());  // Return an empty list if no rates found
            }

            // Pass the rates to the view
            return View(rates);
        }


        // GET: Rate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rate rate)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Rate.Add(rate);
                _unitOfWork.save();
                TempData["success"] = "You have successfully created the rate";
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _unitOfWork.Rate.Get(r => r.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _unitOfWork.Rate.Get(r => r.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rate rate)
        {
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Rate.Update(rate);
                _unitOfWork.save();
                TempData["success"] = "You have successfully edited the rate";
                return RedirectToAction(nameof(Index));
            }
            return View(rate);
        }

        // GET: Rate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _unitOfWork.Rate.Get(r => r.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rate = await _unitOfWork.Rate.Get(r => r.Id == id);
            if (rate != null)
            {
                _unitOfWork.Rate.Remove(rate);
            }

            _unitOfWork.save();
            TempData["success"] = "You have successfully deleted the rate";

            return RedirectToAction(nameof(Index));
        }
    }
}