using MvcMovie.Models;


namespace MvcMovie.Repositories
{
    public interface IProductRepository : IRepository<Product> 
    {
         void Update(Product product);
    }
}