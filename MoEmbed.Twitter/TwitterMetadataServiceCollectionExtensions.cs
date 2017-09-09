using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoEmbed.Providers;

namespace MoEmbed.Twitter
{
    public static class TwitterMetadataServiceCollectionExtensions
    {
        public static void AddTwitterMetadataProviders(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(TwitterMetadataProvider), ServiceLifetime.Singleton));
        }

        public static void ConfigureTwitterMetadataProviderOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TwitterMetadata>(configuration);
        }
    }
}