using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class PurchaseDetailRepository : Repository<PurchaseDetail>, IPurchaseDetailRepository
{
    private MvcMovieContext _db;

    public PurchaseDetailRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(PurchaseDetail purchaseDetail)
    {
        _db.PurchaseDetails.Update(purchaseDetail);
    }
}