using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class SaleDetailRepository : Repository<SaleDetail>, ISaleDetailRepository
{
    private MvcMovieContext _db;

    public SaleDetailRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(SaleDetail saleDetail)
    {
        _db.SaleDetails.Update(saleDetail);
    }
}