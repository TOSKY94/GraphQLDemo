using GraphQLDemo.Models;
using GraphQLDemo.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Types;
public class Mutation
{
    public async Task<Author> AddAuthor(Author author, [Service] AuthorRepository authorRepository, [Service] BookRepository bookRepository, [Service] ITopicEventSender eventSender)
    {
        authorRepository.AddAuthor(author);
        
        // Publish the event for onBookAdded subscription
        await eventSender.SendAsync(nameof(Subscription.OnAuthorAdded), author);
        return author;
    }
}
