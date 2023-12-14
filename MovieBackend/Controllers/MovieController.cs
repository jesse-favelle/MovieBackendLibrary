using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MovieBackend.Repositorys;
using MovieBackend.Services;
using Newtonsoft.Json.Linq;

namespace MovieBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieRepository _movieRepository;
        private IMovieService _movieService;
        private IOpenMovieDbRepository   _openMovieDbRepository;

        public MovieController(IMovieService movieService, IMovieRepository movieRepository, IOpenMovieDbRepository openMovieDbRepository)
        {
            _movieRepository = movieRepository;
            _openMovieDbRepository = openMovieDbRepository;
            _movieService = movieService;

        }

        [HttpGet(Name = "GetMovies")]
        public IActionResult GetMovies()
        {

            return Ok(_movieRepository.GetMovies());
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie(int id)
        {
            if(id == 0)  
            {
                return BadRequest("Must be a valid id");
            }
            Movie foundMovie = _movieRepository.GetMovie(id);

           return foundMovie == null ? NotFound() : Ok(foundMovie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {        
            string openMovieJsonStringResponse = await _openMovieDbRepository.SearchByMovieTitle(movie.Title);
           
            var openMovieJsonObject =  JObject.Parse(openMovieJsonStringResponse);
            movie.IMDBRating = Convert.ToDouble(openMovieJsonObject["imdbRating"]);

            _movieService.CreateMovie(movie);

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(Movie movie)
        {

            if (_movieRepository.GetMovie(movie.Id) == null)
            {
                return NotFound();
            }
            _movieService.UpdateMovie(movie);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if(_movieRepository.GetMovie(id) == null)
            {
                return NotFound();
            }
            _movieService.deleteMovie(id);
            return Ok();
        }

    }
}