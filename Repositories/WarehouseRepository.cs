using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
{
    private MvcMovieContext _db;
    public WarehouseRepository(MvcMovieContext mvcMovieContext) : base(mvcMovieContext)
    {
        _db = mvcMovieContext;
    }

    public void Update(Warehouse warehouse)
    {
        _db.Update(warehouse);
    }
}