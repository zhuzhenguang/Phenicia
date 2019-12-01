using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Phoenicia.Infrastructures;

namespace Phoenicia.Test.Base
{
    public class CustomWebApplicationFactory : WebApplicationFactory<FakeStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                .UseEnvironment("Testing")
                .UseStartup<FakeStartup>();
        }
    }
}