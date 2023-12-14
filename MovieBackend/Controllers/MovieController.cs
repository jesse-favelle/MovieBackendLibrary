using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MovieBackend.Models;
using MovieBackend.Repositorys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;

namespace MovieBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private IMovieService _movieService;
        private IMovieRepository _movieRepository;
        private IOpenMovieDbRepository _openMovieDbRepository;

        public MovieController(ILogger<MovieController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _movieService = new MovieService(configuration);
            _movieRepository = new MovieRepository();
            _openMovieDbRepository = new OpenMovieDBRepository(configuration);

        }

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {

            return _movieRepository.GetMovies();
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public Movie GetMovie(int id)
        {
           return _movieRepository.GetMovie(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (!_movieService.ValidateMovie(movie))
            {

            }

            string openMovieJsonStringResponse = await _openMovieDbRepository.SearchByMovieTitle(movie.Title);
           
            var openMovieJsonObject =  JObject.Parse(openMovieJsonStringResponse);
            movie.IMDBRating = Convert.ToDouble(openMovieJsonObject["imdbRating"]);

            _movieService.CreateMovie(movie);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(Movie movie)
        {
            if (!_movieService.ValidateMovie(movie))
            {
                return BadRequest();
            }
            _movieService.UpdateMovie(movie);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.deleteMovie(id);
            return Ok();
        }

    }
}