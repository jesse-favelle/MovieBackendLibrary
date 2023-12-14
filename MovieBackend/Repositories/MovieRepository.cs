using System;

public class MovieRepository : IMovieRepository
{
	public MovieRepository()
	{
	}
	public List<Movie> GetMovies()
	{
		/*call the db, get all movies;
		 * try
		 */

		return movies;
	
		
	}
	public Movie GetMovie(int id)
	{
		var movie =  movies.Find(x => x.Id == id);
		
		return movie;
	}

	public void AddMovie(Movie movie)
	{
		try
		{
			movies.Add(movie);
		}
		catch
		{
			throw new Exception("Couldn't Add Movie");
		}
	}

	public void UpdateMovie(Movie movie)
    {
        var movieToUpdate = movies.Find(x => x.Id == movie.Id);

        UpdateMovie(movie, movieToUpdate);

    }

    private static void UpdateMovie(Movie movie, Movie? movieToUpdate)
    {
        movieToUpdate.Title = movie.Title;
        movieToUpdate.ReleaseDate = movie.ReleaseDate;
        movieToUpdate.Genre = movie.Genre;
    }

    public void DeleteMovie(int id) { 
		movies.Remove(GetMovie(id));
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
	void AddMovie(Movie movie);
	void UpdateMovie(Movie movie);
	void DeleteMovie(int id);
}
