using System;
using System.ComponentModel.DataAnnotations;



public class Movie		
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Genre { get; set; }
	public DateOnly ReleaseDate { get; set; }

	public double IMDBRating {  get; set; }

}
