using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    public abstract class InfrastructureTestBase
    {
        protected InfrastructureTestBase()
        {
            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("IntegrationTest")
                .UseDefaultServiceProvider(options => { options.ValidateScopes = true; })
                .ConfigureAppConfiguration((context, builder) => { builder.AddEnvironmentVariables(); })
                .ConfigureTestServices(ConfigureTestServices)
                .UseStartup<Startup>();

            Server = new TestServer(hostBuilder);
        }

        protected TestServer Server { get; }

        public void Dispose()
        {
            Server.Dispose();
        }

        protected abstract void ConfigureTestServices(IServiceCollection services);
    }
}
