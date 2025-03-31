using GraphQLDemo.Models;

namespace GraphQLDemo.Types;
public class Subscription
{
    [Subscribe]
    [Topic(nameof(OnAuthorAdded))]
    public Author OnAuthorAdded([EventMessage] Author author) => author;
}