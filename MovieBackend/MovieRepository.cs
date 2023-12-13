using System;

public class MovieRepository
{
	public MovieRepository()
	{
	}
	public bool GetMovie(int id)
	{
		return true;
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
	Movie GetMovie(Movie movie);
	void AddMovie(Movie movie);
	void UpdateMovie(Movie movie);
	void DeleteMovie(int id);
}
