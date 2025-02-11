using MvcMovie.Models;

namespace MvcMovie.Repositories;
public interface IPaymentMethodRepository : IRepository<PaymentMethod>
{
    public void Update(PaymentMethod paymentMethod);
}