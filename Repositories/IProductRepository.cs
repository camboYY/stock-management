using MvcMovie.Models;


namespace MvcMovie.Repositories
{
    public interface IProductRepository : IRepository<Product> 
    {
        Task<IEnumerable<Product>> GetAll(Func<Product, bool> value);

        void Update(Product product);
    }
}