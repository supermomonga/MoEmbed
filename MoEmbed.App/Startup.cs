using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoEmbed.Twitter;

namespace MoEmbed
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddRouting();

            services.AddTwitterMetadataProviders();
            services.ConfigureTwitterMetadataProviderOptions(Configuration);

            services.AddMetadataProviders();
            services.ConfigureMetadataProviderOptions(Configuration);

            services.AddSingleton<IMetadataCache, MemoryMetadataCache>();
            services.AddSingleton<MetadataService>();
            services.AddSingleton<HttpMetadataHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("api", app.ApplicationServices.GetService<HttpMetadataHandler>().HandleAsync);
            routeBuilder.MapGet("", async (c) =>
            {
                using (var s = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("MoEmbed.Public.index.html"))
                {
                    c.Response.ContentType = "text/html";
                    await s.CopyToAsync(c.Response.Body).ConfigureAwait(false);
                }
            });

            app.UseRouter(routeBuilder.Build());
        }
    }
}