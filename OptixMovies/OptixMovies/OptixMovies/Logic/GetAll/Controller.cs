using MediatR;
using Microsoft.AspNetCore.Mvc;
using OptixMovies.Models;

namespace OptixMovies.Logic.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetAllController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAll()
        {
            return await _mediator.Send(new Request());
        }
    }
}