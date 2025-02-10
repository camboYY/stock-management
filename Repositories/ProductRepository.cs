using System.Linq.Expressions;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        
        private MvcMovieContext _db;

        public ProductRepository(MvcMovieContext db):base(db)
        {
            _db = db;
        }

        public  void Update(Product product)
        {
            _db.Product.Update(product);
        }
    }
}