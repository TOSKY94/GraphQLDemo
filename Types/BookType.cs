using GraphQLDemo.Models;
using GraphQLDemo.Repositories;
using GraphQLDemo.Resolvers;

namespace GraphQLDemo.Types;
public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(b => b.Id).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.Title).Type<NonNullType<StringType>>();
        descriptor.Field(b => b.PublicationYear).Type<NonNullType<IntType>>();
        descriptor.Field(b => b.Genre).Type<EnumType<Genre>>();
        descriptor.Field("author")
            .ResolveWith<AuthorResolver>(a => a.GetAuthorByBookId(default!, default!))
            .Name("author")
            .Type<AuthorType>()
            .Description("The author of the book.");
    }
}