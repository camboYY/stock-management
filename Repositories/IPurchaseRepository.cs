using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IPurchaseRepository : IRepository<Purchase>
{
    void Update(Purchase purchase);

    int SaveChanges();

}