using FastEndpoints;

namespace RiverBooks.Books;

internal class CreateBookEndpoint(IBookService _bookService) : Endpoint<CreateBookRequest, BookDto>
{
    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var newBookDto = new BookDto(request.Id ?? Guid.NewGuid(), request.Title, request.Author, request.Price);
        
        await _bookService.CreateBookAsync(newBookDto);

        await SendCreatedAtAsync<GetBookByIdEndpoint>(new {newBookDto.Id}, newBookDto);
    }
}
