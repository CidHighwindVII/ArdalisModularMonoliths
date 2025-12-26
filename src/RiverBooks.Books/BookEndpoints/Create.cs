using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class Create(IBookService _bookService) : Endpoint<CreateRequest, BookDto>
{
    public override void Configure()
    {
        Post("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRequest request, CancellationToken cancellationToken)
    {
        var newBookDto = new BookDto(request.Id ?? Guid.NewGuid(), request.Title, request.Author, request.Price);
        
        await _bookService.CreateBookAsync(newBookDto);

        await SendCreatedAtAsync<GetById>(new {newBookDto.Id}, newBookDto);
    }
}
