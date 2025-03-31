using GraphQLDemo.Models;
using GraphQLDemo.Repositories;

namespace GraphQLDemo.Types;
public class Query{
    public IQueryable<Book> GetBooks([Service] BookRepository bookRepository) => bookRepository.GetBooks();

    public Book GetBookById(int id, [Service] BookRepository bookRepository) => bookRepository.GetBookById(id);

    public IQueryable<Author> GetAuthors([Service] AuthorRepository authorRepository) => authorRepository.GetAuthors();

    public Author GetAuthorById(int id, [Service] AuthorRepository authorRepository) => authorRepository.GetAuthorById(id);

    public Author GetAuthorByBookId(int bookId, [Service] AuthorRepository authorRepository) => authorRepository.GetAuthorByBookId(bookId) ?? throw new InvalidOperationException("Author not found for the given Book ID.");
}