using GraphQLDemo.Models;
namespace GraphQLDemo.Repositories;

public class AuthorRepository
{
    private readonly List<Author> _authors =
    [
        new() { Id = 1, Name = "George Orwell", Biography = "English novelist and essayist.", DateOfBirth = new DateTime(1903, 6, 25), Books = [
             new() { Id = 1, Title = "1984",  PublicationYear = 1949, Genre = Genre.Fantasy, AuthorId = 1 },
             new() { Id = 2, Title = "Animal Farm",  PublicationYear = 1945, Genre = Genre.Fantasy, AuthorId = 1 }
             ] },
        new() { Id = 2, Name = "Frank Herbert", Biography = "American science fiction author.", DateOfBirth = new DateTime(1920, 10, 8), Books = [
             new() { Id = 3, Title = "Dune", PublicationYear = 1965, Genre = Genre.ScienceFiction, AuthorId = 2 },
             new() { Id = 4, Title = "God Emperor of Dune", PublicationYear = 1981, Genre = Genre.ScienceFiction, AuthorId = 2 }
             ] },
        new() { Id = 3, Name = "Douglas Adams", Biography = "English author and humorist.", DateOfBirth = new DateTime(1952, 3, 11), Books = [
             new() { Id = 5, Title = "The Hitchhiker's Guide to the Galaxy", PublicationYear = 1979, Genre = Genre.ScienceFiction, AuthorId = 3 },
             new() { Id = 6, Title = "Dirk Gently's Holistic Detective Agency", PublicationYear = 1987, Genre = Genre.ScienceFiction, AuthorId = 3 }
             ] },
    ];

    private readonly BookRepository _books;

    public AuthorRepository(BookRepository books)
    {
        _books = books;
    }
    public IQueryable<Author> GetAuthors() => _authors.AsQueryable();

    public Author GetAuthorById(int id) => _authors.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException("Author not found.");

    public Author? GetAuthorByBookId(int bookId) 
    {
        return _authors.FirstOrDefault(a => a.Books.Any(b => b.Id == bookId)) ?? throw new GraphQLException("Author not found.");
    }
    public void AddAuthor(Author author)
    {
        var existingAuthor = _authors.FirstOrDefault(a => a.Name.Equals(author.Name, StringComparison.OrdinalIgnoreCase) && a.DateOfBirth.Date == author.DateOfBirth.Date);

        if (existingAuthor != null) throw new GraphQLException("Author already exists.");

        author.Id = _authors.Max(a => a.Id) + 1;
        _authors.Add(author);
        _books.AddBooks(author.Books, author.Id);
    }
}
