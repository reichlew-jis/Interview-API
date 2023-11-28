using Xunit;

namespace Interview.Api.Integration.Test.Setup;

[CollectionDefinition(nameof(MockWebApiCollection))]
public class MockWebApiCollection : ICollectionFixture<MockWebApiFactory>
{
}
