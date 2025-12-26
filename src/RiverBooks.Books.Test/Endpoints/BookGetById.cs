using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Test.Endpoints;

public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper) : TestClass<Fixture>(fixture, outputHelper)
{
    [Theory]
    [InlineData("A89F6CD7-4693-457B-9009-02205DBBFE45", "The Fellowship of the Ring")]
    public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
    {
        var id = Guid.Parse(validId);
        var request = new GetByIdRequest { Id = id };
        var testResult = await Fixture.Client.GETAsync<GetById, GetByIdRequest, BookDto>(request);

        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Should().Be(expectedTitle);
    }
}
