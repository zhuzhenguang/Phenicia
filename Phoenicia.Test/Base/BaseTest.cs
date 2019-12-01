using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Phoenicia.Test.Base
{
    public class BaseTest
    {
        protected readonly WebApplicationFactory<FakeStartup> Factory;
        protected ServiceProvider Scope;

        protected BaseTest()
        {
            Factory = new CustomWebApplicationFactory().WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services => Scope = services.BuildServiceProvider()));
        }
    }
}