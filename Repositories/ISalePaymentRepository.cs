using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface ISalePaymentRepository : IRepository<SalePayment>
{

    void Update(SalePayment salePayment);


}