using GraphQLDemo.Models;

namespace GraphQLDemo.Repositories;
public class BookRepository
{
    private readonly List<Book> _books =
    [
        new() { Id = 1, Title = "1984", PublicationYear = 1949, Genre = Genre.Fantasy, AuthorId = 1 },
        new() { Id = 2, Title = "Animal Farm", PublicationYear = 1945, Genre = Genre.Fantasy, AuthorId = 1 },
        new() { Id = 3, Title = "Dune", PublicationYear = 1965, Genre = Genre.ScienceFiction, AuthorId = 2 },
        new() { Id = 4, Title = "God Emperor of Dune", PublicationYear = 1981, Genre = Genre.ScienceFiction, AuthorId = 2 },
        new() { Id = 5, Title = "The Hitchhiker's Guide to the Galaxy", PublicationYear = 1979, Genre = Genre.ScienceFiction, AuthorId = 3 },
        new() { Id = 6, Title = "Dirk Gently's Holistic Detective Agency", PublicationYear = 1987, Genre = Genre.ScienceFiction, AuthorId = 3 },
        ];

    public IQueryable<Book> GetBooks() => _books.AsQueryable();

    public IQueryable<Book> GetBooksByAuthorId(int? authorId) => _books.Where(b => b.AuthorId == authorId).AsQueryable();

    public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id) ?? throw new GraphQLException("Book not found.");

    public void AddBook(Book book)
    {
        book.Id = _books.Max(b => b.Id) + 1;
        _books.Add(book);
    }

    public void AddBooks(List<Book> books, int authorId)
    {
        foreach (var book in books)
        {
            var bookExist = _books.Any(b => b.Title == book.Title && b.PublicationYear == book.PublicationYear && b.Genre == book.Genre && b.AuthorId == authorId);
            if (!bookExist)
            {
                book.Id = _books.Max(b => b.Id) + 1;
                book.AuthorId = authorId;
                _books.Add(book);
            }

        }
    }
}