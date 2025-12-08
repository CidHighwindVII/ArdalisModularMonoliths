namespace RiverBooks.Books;

public record UpdateBookPriceRequest(Guid Id, Decimal NewPrice);
