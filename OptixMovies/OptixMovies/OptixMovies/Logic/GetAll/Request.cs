using MediatR;
using OptixMovies.Models;

namespace OptixMovies.Logic.GetAll
{
    public class Request : IRequest<IEnumerable<MovieResponse>>
    {
    }
}