using MovieBackend.Repositorys;

namespace MovieBackend.Services
{
    public class MovieService : IMovieService
    {
        IMovieRepository _repository;

        public MovieService(IConfiguration configuration)
        {
            _repository = new MovieRepository();
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
                _repository.UpdateMovie(updatedMovie);
            }
            catch
            {
                return false;
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
                return false;
            }
            return true;
        }
    }

    public interface IMovieService
    {
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie updatedMovie);
        bool deleteMovie(int id);
    }
}
