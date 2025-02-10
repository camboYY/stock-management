using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public interface ICategoryRepository : IRepository<Category> 
    {
        void Update(Category category);
    }
}