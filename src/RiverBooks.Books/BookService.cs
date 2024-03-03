namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return [ 
            new BookDto(Guid.NewGuid(), "Harry potter and the philosopher stone", "J.K. Rowling"),
            new BookDto(Guid.NewGuid(), "Harry potter and the secret chamber", "J.K. Rowling"),
            new BookDto(Guid.NewGuid(), "Harry potter and the prisioner of askaban", "J.K. Rowling")
        ];
    }
}
