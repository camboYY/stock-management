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

    public int SaveChanges()
    {
        foreach (var entry in _db.ChangeTracker.Entries<Purchase>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.PurchaseOrderNumber = GeneratePurchaseOrderNumber(entry.Entity);
            }
        }
        return _db.SaveChanges();
    }

    private string GeneratePurchaseOrderNumber(Purchase order)
    {
        return $"PO-{order.Id.ToString("D4")}";
    }
}