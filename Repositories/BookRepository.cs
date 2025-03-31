using GraphQLDemo.Models;

namespace GraphQLDemo.Repositories;
public class BookRepository
{
    private readonly List<Book> _books =
    [
        new() { Id = 1, Title = "1984", Author = "George Orwell", PublicationYear = 1949, Genre = Genre.Fiction },
        new() { Id = 2, Title = "Dune", Author = "Frank Herbert", PublicationYear = 1965, Genre = Genre.ScienceFiction },
        new() { Id = 3, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", PublicationYear = 1979, Genre = Genre.ScienceFiction }
    ];

    public IQueryable<Book> GetBooks() => _books.AsQueryable();

    public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id) ?? throw new InvalidOperationException("Book not found.");

    public void AddBook(Book book)
    {
        book.Id = _books.Max(b => b.Id) + 1;
        _books.Add(book);

    }
}