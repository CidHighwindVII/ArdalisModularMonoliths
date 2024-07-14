namespace RiverBooks.Books;

public class ListBooksResponse
{
    public List<BookDto> Books { get; set; }

    public ListBooksResponse(List<BookDto> books)
    {
        Books = books;
    }
}
