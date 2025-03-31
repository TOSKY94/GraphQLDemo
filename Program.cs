using GraphQLDemo.Repositories;
using GraphQLDemo.Types;

var builder = WebApplication.CreateBuilder(args);

// Add GraphQL services to the container
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddType<AuthorType>()
    .AddType<BookType>();

// Add the BookRepository as a singleton service
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddSingleton<AuthorRepository>();

var app = builder.Build();

// Configure GraphQL endpoint
app.MapGraphQL();

// Configure the GraphQL WebSocket endpoint for subscriptions
app.UseWebSockets();

app.Run();
