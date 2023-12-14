using System;

public class MovieRepository : IMovieRepository
{
	public MovieRepository()
	{
	}
	public List<Movie> GetMovies()
	{
		//call the db, get all movies;

		return new List<Movie>
		{
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
			}
	
		};
	}
	public Movie GetMovie(int id)
	{
		//call the repository, passing in the id normally
		return new Movie {
			Id = id, 
			Title = "Phantom Of The Paradise",
			Genre = "Musical",
			IMDBRating = 7.7,
			ReleaseDate = new DateOnly(1979, 3, 3) 
		};
	}

	public void AddMovie(Movie movie)
	{

	}

	public void UpdateMovie(Movie movie)
	{

	}

	public void DeleteMovie(int id) { }
	
}

public interface IMovieRepository
{
	List<Movie> GetMovies();
	Movie GetMovie(int id);
	void AddMovie(Movie movie);
	void UpdateMovie(Movie movie);
	void DeleteMovie(int id);
}
