using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    private MvcMovieContext _db;

    public PurchaseRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Purchase purchase)
    {
        _db.Purchases.Update(purchase);
    }

}