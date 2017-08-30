using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoEmbed.Providers;

namespace MoEmbed
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var routeBuilder = new RouteBuilder(app);

            var service = new MetadataService(
                                loggerFactory,
                                new MemoryMetadataCache(app.ApplicationServices.GetService<IMemoryCache>()));

            var twitterConsumerKey = Configuration["TwitterConsumerKey"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_KEY");
            var twitterConsumerSecret = Configuration["TwitterConsumerSecret"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_SECRET");
            if (!string.IsNullOrEmpty(twitterConsumerKey) && !string.IsNullOrEmpty(twitterConsumerSecret))
            {
                service.Providers.Add(new TwitterMetadataProvider(twitterConsumerKey, twitterConsumerSecret));
            }
            {
                var amazon = AmazonMetadataProvider.GetInstance(Configuration);
                if (amazon != null)
                {
                    service.Providers.Add(amazon);
                }
            }
            service.Providers.Add(new ImgurMetadataProvider());
            service.Providers.Add(new PixivMetadataProvider());
            service.Providers.Add(new NicovideoMetadataProvider());
            service.Providers.Add(new DroplrMetadataProvider());
            service.Providers.Add(new AnitvMetadataProvider());
            service.Providers.AddRange(OEmbedProxyMetadataProvider.CreateKnownHandlers());
            service.Providers.Add(new UnknownMetadataProvider());
            routeBuilder.MapGet("api", new HttpMetadataHandler(loggerFactory, service).HandleAsync);
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
