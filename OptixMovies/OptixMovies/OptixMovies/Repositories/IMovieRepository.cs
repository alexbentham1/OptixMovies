using OptixMovies.Entities;

namespace OptixMovies.Repositories
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAll();
    }
}