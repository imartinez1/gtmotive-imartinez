using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GtMotive.Estimate.Microservice.InfrastructureTests
{
    internal sealed class TestWebApplication : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IAuthenticationSchemeProvider>();
                services.RemoveAll<IAuthenticationService>();

                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });

                services.AddSingleton<IAuthenticationSchemeProvider, MockSchemeProvider>();
            });
        }
    }
}
