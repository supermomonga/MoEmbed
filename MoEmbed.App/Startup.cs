using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoEmbed.Handlers;

namespace MoEmbed
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

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
            var api = new Api(loggerFactory);

            var twitterConsumerKey = Configuration["TwitterConsumerKey"];
            var twitterConsumerSecret = Configuration["TwitterConsumerSecret"];
            if(!string.IsNullOrEmpty(twitterConsumerKey) && !string.IsNullOrEmpty(twitterConsumerSecret))
            {
                api.Handlers.Add(new TwitterEmbedObjectHandler(twitterConsumerKey, twitterConsumerSecret));
            }

            api.Handlers.AddRange(RemoteEmbedObjectHandler.CreateKnownHandlers());
            routeBuilder.MapGet("", api.Embed);

            app.UseRouter(routeBuilder.Build());
        }
    }
}












