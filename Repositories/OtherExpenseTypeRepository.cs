using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class OtherExpenseTypeRepository : Repository<OtherExpenseType>, IOtherExpenseTypeRepository
{
    private MvcMovieContext _db;

    public OtherExpenseTypeRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(OtherExpenseType otherExpenseType)
    {
        _db.OtherExpenseTypes.Update(otherExpenseType);
    }

}