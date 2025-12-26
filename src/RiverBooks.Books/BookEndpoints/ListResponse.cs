namespace RiverBooks.Books.BookEndpoints;

public class ListResponse
{
    public List<BookDto> Books { get; set; } = new List<BookDto>();
}
