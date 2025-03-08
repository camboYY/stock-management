
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class RateRepository : IRateRepository
{
    private readonly MvcMovieContext _context;

    public RateRepository(MvcMovieContext context)
    {
        _context = context;
    }

    // Fetching all rates with pagination
    public async Task<IEnumerable<Rate>> GetAll(int? page)
    {
        int pageSize = 10;  // Set the page size you need
        int pageIndex = page ?? 1;  // Default to page 1 if no page is provided

        // Return an empty list if no records are found
        var rates = await _context.Rates
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return rates ?? new List<Rate>();  // Ensure that null is never returned
    }

    public async Task<Rate> Get(Expression<Func<Rate, bool>> predicate)
    {
        return await _context.Rates.FirstOrDefaultAsync(predicate);
    }

    public void Add(Rate rate)
    {
        _context.Rates.Add(rate);
    }

    public void Update(Rate rate)
    {
        _context.Rates.Update(rate);
    }

    public void Remove(Rate rate)
    {
        _context.Rates.Remove(rate);
    }
}
