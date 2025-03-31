namespace GraphQLDemo.Models;
public class Book
{
    public int? Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int PublicationYear { get; set; }
    public Genre Genre { get; set; }
}

public enum Genre
{
    Fiction,
    NonFiction,
    ScienceFiction,
    Mystery,
    Fantasy
}