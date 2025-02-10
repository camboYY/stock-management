using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface ISupplierRepository : IRepository<Supplier>
{

    public void Update(Supplier supplier);
}