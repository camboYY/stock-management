using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using X.PagedList;
using X.PagedList.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MvcMovieContext _db;
        internal DbSet<T> dbSet;
        public Repository(MvcMovieContext mvcMovieContext)
        {
            _db = mvcMovieContext;
            dbSet = _db.Set<T>();
        }
        public async void Add(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string? inCludes = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(inCludes))
            {
                foreach (var includeProp in inCludes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstAsync(filter);
        }

        public async Task<IPagedList<T>> GetAll(int? page = 1, string? inCludes = null)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(inCludes))
            {
                foreach (var includeProp in inCludes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            var list = await query.ToListAsync();
            return list.ToPagedList(pageNumber, pageSize);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}