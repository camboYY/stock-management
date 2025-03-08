using System.Linq.Expressions;
using X.PagedList;

namespace MvcMovie.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IPagedList<T>> GetAll(int? page = 1, string? inCludes = null);
        Task<T> Get(Expression<Func<T, bool>> filter, string? inCludes = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter, string? inCludes = null);
        void AddRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);

        Task<bool> Exists(Expression<Func<T, bool>> predicate);
        
    }
}
