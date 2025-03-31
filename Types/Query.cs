using GraphQLDemo.Models;
using GraphQLDemo.Repositories;

namespace GraphQLDemo.Types;
public class Query{
    public IQueryable<Book> GetBooks([Service] BookRepository bookRepository) => bookRepository.GetBooks();

    public Book GetBookById(int id, [Service] BookRepository bookRepository) => bookRepository.GetBookById(id);
}