using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MoEmbed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            var serverport = config.GetValue<int?>("port") ?? 5000;
            var serverurls = $"http://*:{ serverport }";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(serverurls)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}

