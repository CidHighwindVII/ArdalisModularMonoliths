using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

internal interface IBookService
{
    IEnumerable<BookDto> ListBooks();
}

public record BookDto(Guid id, string Title, string Author);

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return [ 
            new BookDto(Guid.NewGuid(), "Harry potter and the philosopher stone", "J.K. Rowling"),
            new BookDto(Guid.NewGuid(), "Harry potter and the secret chamber", "J.K. Rowling"),
            new BookDto(Guid.NewGuid(), "Harry potter and the prisioner of askaban", "J.K. Rowling")
        ];
    }
}

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
}

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}