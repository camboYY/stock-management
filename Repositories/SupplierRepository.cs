using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    private MvcMovieContext _db;
    public SupplierRepository(MvcMovieContext mvcMovieContext) : base(mvcMovieContext)
    {
        _db = mvcMovieContext;
    }

    public void Update(Supplier supplier)
    {
        _db.Update(supplier);
    }
}