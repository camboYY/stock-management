using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface ISaleDetailRepository : IRepository<SaleDetail>
{
    void Update(SaleDetail saleDetail);
}