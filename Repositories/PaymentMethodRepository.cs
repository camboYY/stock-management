using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
{
    private MvcMovieContext _db;

    public PaymentMethodRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(PaymentMethod paymentMethod)
    {
        _db.PaymentMethods.Update(paymentMethod);
    }

}