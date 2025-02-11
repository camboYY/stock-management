using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class ProductUnitRepository : Repository<ProductUnit>, IProductUnitRepository
{
    private MvcMovieContext _db;
    public ProductUnitRepository(MvcMovieContext mvcMovieContext) : base(mvcMovieContext)
    {
        _db = mvcMovieContext;
    }

    public void Update(ProductUnit productUnit)
    {
        _db.Update(productUnit);
    }
}