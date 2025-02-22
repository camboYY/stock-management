using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class PurchasePaymentRepository : Repository<PurchasePayment>, IPurchasePaymentRepository
{
    private MvcMovieContext _db;

    public PurchasePaymentRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(PurchasePayment purchasePayment)
    {
        _db.PurchasePayments.Update(purchasePayment);
    }
}