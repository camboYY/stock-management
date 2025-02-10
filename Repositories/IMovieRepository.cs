using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public interface IMovieRepository : IRepository<Movie> {
        void update(Movie movie);
        void save();
        void Remove(Movie movie);
    }
}