using System.Linq.Expressions;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        
        private MvcMovieContext mvcMovieContext;

        public MovieRepository(MvcMovieContext mvcMovieContext):base(mvcMovieContext)
        {
            this.mvcMovieContext = mvcMovieContext;
        }

        public void save()
        {
            mvcMovieContext.SaveChanges();
        }

        public void update(Movie movie)
        {
            mvcMovieContext.Movie.Update(movie);
        }
    }
}