using RiberBooks.Books;

namespace RiverBooks.Books;

internal interface IReadOnlyRepository
{
    Task<Book?> GetByIdAsync(Guid id);
    Task<List<Book>> ListAsync();
}
