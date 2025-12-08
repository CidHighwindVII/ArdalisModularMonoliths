using FastEndpoints;

namespace RiverBooks.Books;

internal class UpdateBookPriceEndpoint(IBookService _bookService) : Endpoint<UpdateBookPriceRequest, BookDto>
{
    // public override void Configure()
    // {
    //     Put("/book/{Id}");
    //     AllowAnonymous();
    // }

    public override void Configure()
    {
        Put("/book/{Id}/pricehistory");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBookPriceRequest request, CancellationToken cancellationToken)
    {
        // TODO: Handle not found
        await _bookService.UpdateBookPriceAsync(request.Id, request.NewPrice);

        var updatedBook = await _bookService.GetBookByIdAsync(request.Id);
        
        await SendAsync(updatedBook);
    }
}
