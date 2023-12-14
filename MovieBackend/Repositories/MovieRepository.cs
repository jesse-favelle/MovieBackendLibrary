using MovieBackend.Repositorys;
using MovieBackend.Services;
using Newtonsoft.Json.Linq;

public class MovieRepository : IMovieRepository
{
	private IOpenMovieDbRepository _openMovieDBRepository;
	public MovieRepository(IOpenMovieDbRepository openMovieDBRepository)
	{
		_openMovieDBRepository = openMovieDBRepository;
	}
	public List<Movie> GetMovies()
	{
		/*call the db, get all movies;
		 * trycatch
		 */

		return movies;
	}
	public Movie GetMovie(int id)
	{
		var movie = movies.Find(x => x.Id == id);
		
		return movie;
	}

	public List<Movie> AddMovie(Movie movie)
	{
		try
		{
			movies.Add(movie);
		}
		catch
		{
			throw new Exception("Couldn't Add Movie");
		}

		return movies;
	}

	public List<Movie> UpdateMovie(Movie movie)
    {
        var movieToUpdate = movies.Find(x => x.Id == movie.Id);

        UpdateMovie(movie, movieToUpdate);

		return movies;
    }

    private async void UpdateMovie(Movie movie, Movie movieToUpdate)
    {
        movieToUpdate.Title = movie.Title;
        movieToUpdate.ReleaseDate = movie.ReleaseDate;
        movieToUpdate.Genre = movie.Genre;

        string openMovieAPIJsonStringResponse = await _openMovieDBRepository.SearchByMovieTitle(movie.Title);
        var openMovieJsonObject = JObject.Parse(openMovieAPIJsonStringResponse); 
        movieToUpdate.IMDBRating = Convert.ToDouble(openMovieJsonObject["imdbRating"]);
    }

    public List<Movie> DeleteMovie(int id) { 
		movies.Remove(GetMovie(id));
		return movies;
	}

	List<Movie> movies = new List<Movie> {
            new Movie
            {
                Id = 1,
                Title = "Night Of The Comet",
                IMDBRating = 6.3,
                Genre = "Sci-Fi",
                ReleaseDate = new DateOnly(1984, 4, 5)
            },
            new Movie
            {
                Id = 2,
                Title = "Monster Squad",
                IMDBRating = 6.9,
                Genre = "Horror",
                ReleaseDate = new DateOnly(1987, 10, 31)
            },
            new Movie
			{
				Id = 3,
				Title = "Phantom Of The Paradise",
				Genre = "Musical",
				IMDBRating = 7.7,
				ReleaseDate = new DateOnly(1979, 3, 3)
			}
        };
};

public interface IMovieRepository
{
	List<Movie> GetMovies();
	Movie GetMovie(int id);
	List<Movie> AddMovie(Movie movie);
	List<Movie> UpdateMovie(Movie movie);
	List<Movie> DeleteMovie(int id);
}
