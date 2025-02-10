using System.Linq.Expressions;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private MvcMovieContext _db;

        public CategoryRepository(MvcMovieContext db):base(db)
        {
            _db = db;
        }
        
        public void Update(Category category)
        {
            _db.Category.Update(category);
        }
    }
}