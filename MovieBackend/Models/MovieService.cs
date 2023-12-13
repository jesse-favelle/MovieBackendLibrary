using MovieBackend.Controllers;

namespace MovieBackend.Models
{
    public class MovieService : IMovieService
    {
        MovieRepository _repository;

        public MovieService()
        {
            _repository = new MovieRepository();
        }

        public bool ValidateMovie(Movie movie)
        {
            if(movie.Title == null || movie.Title.Length < 100)
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

                if(!_repository.GetMovie(updatedMovie.Id))
                {
                    throw new Exception();
                }

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
