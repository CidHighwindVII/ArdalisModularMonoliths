using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

// REPR design pattern - Request Endpoint Response
internal class List(IBookService bookService) :
    EndpointWithoutRequest<ListResponse>
{
    private readonly IBookService _bookService = bookService;

    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var books = await _bookService.ListBooksAsync();

        await SendAsync(new ListResponse()
        {
            Books = books
        });
    }
}
