using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class SalePaymentRepository : Repository<SalePayment>, ISalePaymentRepository
{
    private MvcMovieContext _db;

    public SalePaymentRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(SalePayment salePayment)
    {
        _db.SalePayments.Update(salePayment);
    }
}