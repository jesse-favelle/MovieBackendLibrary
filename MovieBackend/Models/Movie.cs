using System.ComponentModel.DataAnnotations;

public class Movie		
{
    /*Database Schema would follow this
	CREATE TABLE movies (
        Id int NOT NULL AUTO_INCREMENT,
		Title varchar(1000) NOT NULL,
		Genre varchar(300) NOT NULL,
		ReleaseDate DATE,
		IMDBRating FLOAT,
		PRIMARY KEY(Id)
	);
	CREATE INDEX idxTitle ON Title;
	 */
    [Required]
	public int Id { get; set; }

	[Required]
	public string? Title { get; set; }

	[Required]
	public string? Genre { get; set; }
	[Required]
	public DateOnly ReleaseDate { get; set; }

	public double IMDBRating {  get; set; }

}
