using System.Linq.Expressions;
using MvcMovie.Models;

namespace MvcMovie.Repositories;
public interface IRateRepository
{
    Task<IEnumerable<Rate>> GetAll(int? page);
    Task<Rate> Get(Expression<Func<Rate, bool>> predicate);
    void Add(Rate rate);
    void Update(Rate rate);
    void Remove(Rate rate);
}
