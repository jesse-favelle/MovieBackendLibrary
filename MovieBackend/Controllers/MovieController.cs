using Microsoft.AspNetCore.Mvc;

namespace MovieBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {


        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Movie
            {
               Id = 1,
               Title = "Last Action Hero",
               Genre = "Action",
               Year = 


            })
            .ToArray();
        }

        [HttpGet(Name = "GetMovie")]
        public Movie GetMovie(int id)
        {

        }

        [HttpPost]
    }
}
