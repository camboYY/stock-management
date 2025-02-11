using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IProductUnitRepository : IRepository<ProductUnit>
{
    public void Update(ProductUnit productUnit);
}