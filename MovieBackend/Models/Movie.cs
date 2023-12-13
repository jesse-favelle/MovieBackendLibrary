using System;
using System.ComponentModel.DataAnnotations;


public class Movie		
{
	[Required]
	public int Id { get; set; }

	[Required]
	public string Title;

	[Required]
	public string Genre;
	[Required]
	public DateOnly ReleaseDate { get; set; }

}
