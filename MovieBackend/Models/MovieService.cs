
using MovieBackend.Repositorys;

namespace MovieBackend.Models
{
    public class MovieService : IMovieService
    {
        IMovieRepository _repository;
        IOpenMovieDbRepository _openMovieDbRepository;
        IConfiguration _configuration;


        public MovieService(IConfiguration configuration)
        {
            _repository = new MovieRepository();
            _openMovieDbRepository = new OpenMovieDBRepository(configuration);
        }

        public bool ValidateMovie(Movie movie)
        {
            if(movie.Title == null || movie.Title.Length > 100)
            {
                throw new ArgumentException("Movie Title is not valid");
            }

            if (movie.Genre == null)
            {
                throw new ArgumentException("Movie Genre");
            }
            return true;
        }

        public bool CreateMovie(Movie movie)
        {
            try
            {
                _repository.AddMovie(movie);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateMovie(Movie updatedMovie)
        {
            try
            {

                /*if(!_repository.GetMovie(updatedMovie.Id))
                {
                    throw new Exception();
                }*/

                _repository.UpdateMovie(updatedMovie);
            }
            catch
            {
            }
            return true;
        }

        public bool deleteMovie(int id)
        {
            try
            {
                _repository.DeleteMovie(id);
            }
            catch
            {

            }
            return true;
        }
    }

    public interface IMovieService
    {
        bool CreateMovie(Movie movie);
        bool ValidateMovie(Movie movie);
        bool UpdateMovie(Movie updatedMovie);
        bool deleteMovie(int id);
    }
}
