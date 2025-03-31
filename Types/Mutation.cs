using GraphQLDemo.Models;
using GraphQLDemo.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Types;
public class Mutation
{
    public async Task<Book> AddBook(Book book, [Service] BookRepository bookRepository, [Service] ITopicEventSender eventSender)
    {
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
        {
            throw new GraphQLException("Title and Author are required.");
        }

        bookRepository.AddBook(book);

        // Publish the event for onBookAdded subscription
        await eventSender.SendAsync(nameof(Subscription.OnBookAdded), book);
        return book;
    }
}
