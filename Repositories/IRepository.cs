using System.Linq.Expressions;

namespace MvcMovie.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string? inCludes = null);
        Task<T> Get(Expression<Func<T, bool>> filter, string? inCludes = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
