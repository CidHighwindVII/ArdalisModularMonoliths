using FastEndpoints;

namespace RiverBooks.Books;

internal class DeleteBookEndpoint(IBookService _bookService) : Endpoint<DeleteBookRequest>
{
    public override void Configure()
    {
        Delete("/book/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        // TODO: Handle not found
        await _bookService.DeleteBookAsync(request.Id);

        await SendNoContentAsync();
    }
}
