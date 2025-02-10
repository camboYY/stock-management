using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    private MvcMovieContext _db;

    public BranchRepository(MvcMovieContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Branch branch)
    {
        _db.Branches.Update(branch);
    }

}