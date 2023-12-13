namespace MovieBackend.Models
{
    public class MovieService : IMovieService
    {

        public bool ValidateMovie(Movie movie)
        {
            if(movie.Title == null)
            {

            }
            return true;
        }

        public bool CreateMovie(Movie movie)
        {

            try
            {
                //_respository.CreateMovie(Movie movie)
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
        bool ValidateMovie(Movie movie);
    }
}
