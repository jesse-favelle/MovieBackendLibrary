using Microsoft.AspNetCore.Mvc;
using MovieBackend.Models;
using System.Security.Cryptography.X509Certificates;


namespace MovieBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
            _movieService = new MovieService();
        }

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {

            return Enumerable.Range(1, 5).Select(index => new Movie
            {
                Id = 1,
                Title = "Last Action Hero",
                Genre = "Action",
                ReleaseDate = new DateOnly(1993, 3, 3),

            })
            .ToArray();
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public Movie GetMovie(int id)
        {
            return new Movie
            {
                Id = 1,
                Title = "Last Action Hero",
                Genre = "Action",
                ReleaseDate = new DateOnly(1993, 3, 3),
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (_movieService.ValidateMovie(movie))
            {

            }
            using (var client = new HttpClient())
            {

                string openApiKey = Environment.GetEnvironmentVariable("OpenMovieDBAPIKey");
                string url = "http://www.omdbapi.com/?apikey={openApiKey}&t={title}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();


                _movieService.CreateMovie(movie);

                return Ok(response);

            }
        }

        [HttpPut] 
        public  IActionResult UpdateMovie(Movie movie)
        {

            return Ok(); 
        }

        [HttpDelete]
        public  IActionResult DeleteMovie(int id)
        {
            return Ok();
        }





        }
    }
}
