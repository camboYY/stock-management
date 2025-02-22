using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IPurchasePaymentRepository : IRepository<PurchasePayment>
{

    void Update(PurchasePayment purchasePayment);


}