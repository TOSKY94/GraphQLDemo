using GraphQLDemo.Models;
using GraphQLDemo.Resolvers;

namespace GraphQLDemo.Types;
public class AuthorType: ObjectType<Author>{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Field(a => a.Id).Type<NonNullType<IdType>>();
        descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Biography).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.DateOfBirth).Type<NonNullType<DateTimeType>>();
        descriptor.Field(a => a.Books)
            .ResolveWith<BookResolver>(b => b.GetBooksByAuthorId(default!, default!))
            .Name("books")
            .Type<ListType<NonNullType<BookType>>>()
            .Description("The books written by the author.");
    }
}