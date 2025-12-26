using Xunit.Abstractions;
using FastEndpoints.Testing;

namespace RiverBooks.Books.Test.Endpoints;

// Required because we're testing the apis
public class Fixture(IMessageSink messageSink) : TestFixture<Program>(messageSink)
{
    protected override Task SetupAsync()
    {
        Client = CreateClient();

        return Task.CompletedTask;
    }

    protected override Task TearDownAsync()
    {
        Client.Dispose();

        return base.TearDownAsync();
    }
}
