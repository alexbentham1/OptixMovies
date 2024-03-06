using MediatR;
using OptixMovies.Repositories;
using OptixMovies.Models;

namespace OptixMovies.Logic.GetAll
{
    public class Handler : IRequestHandler<Request, IEnumerable<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepo;

        public Handler(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public Task<IEnumerable<MovieResponse>> Handle(Request request, CancellationToken cancellationToken)
        {
            var items = _movieRepo.GetAll().Select(x => new MovieResponse()
            {
                ReleaseDate = x.Release_Date,
                Title = x.Title,
                Overview = x.Overview,
                Popularity = x.Popularity,
                VoteCount = x.Vote_Count,
                VoteAverage = x.Vote_Average,
                OriginalLanguage = x.Original_Language,
                Genre = x.Genre,
                PosterUrl = x.Poster_Url
            }).AsEnumerable();

            return Task.FromResult(items);
        }
    }
}