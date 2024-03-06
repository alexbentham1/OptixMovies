using OptixMovies.Database;
using OptixMovies.Entities;

namespace OptixMovies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly OptixContext _context;

        public MovieRepository(OptixContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> GetAll() => _context.Movies.AsQueryable();
    }
}
