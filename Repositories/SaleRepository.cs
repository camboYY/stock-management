using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    private MvcMovieContext _db;

    public SaleRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Sale sale)
    {
        _db.Sales.Update(sale);
    }

}