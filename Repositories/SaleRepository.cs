using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public interface ISaleRepository : IRepository<Sale>
    {
    }

    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(MvcMovieContext context) : base(context) {}
    }
}