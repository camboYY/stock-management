using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IPurchaseDetailRepository : IRepository<PurchaseDetail>
{
    void Update(PurchaseDetail purchaseDetail);
}