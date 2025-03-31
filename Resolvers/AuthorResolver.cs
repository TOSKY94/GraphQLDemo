using GraphQLDemo.Repositories;
using GraphQLDemo.Models;

namespace GraphQLDemo.Resolvers;

public class AuthorResolver{
    public Author? GetAuthorByBookId([Parent] Book book, [Service] AuthorRepository authorRepository) => authorRepository.GetAuthorByBookId(book.Id);
}


