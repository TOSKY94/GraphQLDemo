using GraphQLDemo.Models;

namespace GraphQLDemo.Types;
public class Subscription
{
    [Subscribe]
    [Topic(nameof(OnBookAdded))]
    public Book OnBookAdded([EventMessage] Book book) => book;
}