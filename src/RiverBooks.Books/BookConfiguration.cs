using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiberBooks.Books;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    internal static readonly Guid Book1Guid = new Guid("c4711563-5e2e-40c2-a5bc-719991847564");
    internal static readonly Guid Book2Guid = new Guid("d8dab9eb -4e9c-43fc-b01b-a4ad6af9d318");
    internal static readonly Guid Book3Guid = new Guid("2461e083-026f-49c0-9cb8-54c2ef31da34");
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Author)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData()
    {
        var tolkien = "J.K. Rowling";
        yield return new Book(Book1Guid, "Harry Potter and the philosopher stone.", tolkien, 10.99m);
        yield return new Book(Book2Guid, "Harry Potter and the chamber of secrets.", tolkien, 11.99m);
        yield return new Book(Book3Guid, "Harry Potter and the prisioner of askaban.", tolkien, 12.99m);
    }
}
