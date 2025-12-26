using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class Delete(IBookService _bookService) : Endpoint<DeleteRequest>
{
    public override void Configure()
    {
        Delete("/book/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest request, CancellationToken cancellationToken)
    {
        // TODO: Handle not found
        await _bookService.DeleteBookAsync(request.Id);

        await SendNoContentAsync();
    }
}
