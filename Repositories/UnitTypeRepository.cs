using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class UnitTypeRepository : Repository<UnitType>, IUnitTypeRepository
{
    private MvcMovieContext _db;
    public UnitTypeRepository(MvcMovieContext mvcMovieContext) : base(mvcMovieContext)
    {
        _db = mvcMovieContext;
    }

    public void Update(UnitType unitType)
    {
        _db.Update(unitType);
    }
}