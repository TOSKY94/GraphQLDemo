using GraphQLDemo.Repositories;
using GraphQLDemo.Models;

namespace GraphQLDemo.Resolvers;
public class BookResolver
{
    public IQueryable<Book>? GetBooksByAuthorId([Parent] Author author, [Service] BookRepository bookRepository) => bookRepository.GetBooksByAuthorId(author.Id);
}
