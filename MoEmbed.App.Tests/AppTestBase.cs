using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace MoEmbed;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHostBuilder? CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureHostConfiguration(config =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "hostBuilder:reloadConfigOnChange", "false" }
                });
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}

public static class SharedAppFactory
{
    private static readonly Lazy<TestWebApplicationFactory> _factory = new(() => new TestWebApplicationFactory());
    private static readonly Lazy<HttpClient> _client = new(() => _factory.Value.CreateClient());

    public static HttpClient Client => _client.Value;
}
