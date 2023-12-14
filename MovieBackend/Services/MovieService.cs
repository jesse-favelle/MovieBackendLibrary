namespace MovieBackend.Services
{
    public class MovieService : IMovieService
    {
        IMovieRepository _repository;

        public MovieService(IMovieRepository movieRepository)
        {
            _repository = movieRepository;
        }

        public List<Movie> CreateMovie(Movie movie)
        {
            List<Movie> movies;
            try
            {
               movies = _repository.AddMovie(movie);
            }
            catch
            {
                throw new Exception("Couldn't Add Movie");
            }
            return movies;
        }

        public List<Movie> UpdateMovie(Movie updatedMovie)
        {
            List<Movie> movies;
            try
            {
              movies =  _repository.UpdateMovie(updatedMovie);
            }
            catch
            {
                throw new Exception("Couldn't update Movie");
            }
            return movies;
        }

        public List<Movie> deleteMovie(int id)
        {
            List<Movie> movies;
            try
            {
               movies = _repository.DeleteMovie(id);
            }
            catch
            {
                throw new Exception("Couldn't Delete Movie");
            }
            return movies;
        }
    }

    public interface IMovieService
    {
        List<Movie> CreateMovie(Movie movie);
        List<Movie> UpdateMovie(Movie updatedMovie);
        List<Movie> deleteMovie(int id);
    }
}
