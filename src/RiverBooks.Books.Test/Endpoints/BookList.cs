using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Test.Endpoints;

public class BookList(Fixture fixture, ITestOutputHelper outputHelper) : TestClass<Fixture>(fixture, outputHelper)
{
    [Fact]
    public async Task ReturnsThreeBooksAsync()
    {
        var testResult = await Fixture.Client.GETAsync<List, ListResponse>();

        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Books.Count.Should().Be(3);
    }
}
