namespace GraphQLDemo.Models;
public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Book> Books { get; set; } = [];
}