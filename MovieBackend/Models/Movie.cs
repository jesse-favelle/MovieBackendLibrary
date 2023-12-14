using System.ComponentModel.DataAnnotations;

public class Movie		
{
	public int Id { get; set; }

	[Required]
	public string? Title { get; set; }

	[Required ]
	public string? Genre { get; set; }
	[Required]
	public DateOnly ReleaseDate { get; set; }

	public double IMDBRating {  get; set; }

}
