using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public interface IBranchRepository : IRepository<Branch>
{
    void Update(Branch branch);

}