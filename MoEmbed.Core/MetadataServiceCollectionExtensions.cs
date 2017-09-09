using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoEmbed.Providers;

namespace MoEmbed
{
    public static class MetadataServiceCollectionExtensions
    {
        public static void AddMetadataProviders(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(AmazonMetadataProvider), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(ImgurMetadataProvider), ServiceLifetime.Singleton));

            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(PixivMetadataProvider), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(NicovideoMetadataProvider), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(DroplrMetadataProvider), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(AnitvMetadataProvider), ServiceLifetime.Singleton));

            foreach (var t in OEmbedProxyMetadataProvider.CreateKnownHandlerTypes())
            {
                services.Add(new ServiceDescriptor(typeof(IMetadataProvider), t, ServiceLifetime.Singleton));
            }

            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(UnknownMetadataProvider), ServiceLifetime.Singleton));
        }

        public static void ConfigureMetadataProviderOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AmazonMetadataOptions>(configuration);
            services.Configure<ImgurMetadataOptions>(configuration);
        }
    }
}