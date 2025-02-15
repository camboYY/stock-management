using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class OtherIncomeTypeRepository : Repository<OtherIncomeType>, IOtherIncomeTypeRepository
{
    private MvcMovieContext _db;

    public OtherIncomeTypeRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(OtherIncomeType otherIcomeType)
    {
        _db.OtherIncomeTypes.Update(otherIcomeType);
    }

}