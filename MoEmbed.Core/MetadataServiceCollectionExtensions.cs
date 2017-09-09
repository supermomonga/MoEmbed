using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoEmbed.Providers;

namespace MoEmbed
{
    /// <summary>
    /// Provides extension methods to configure <see cref="IMetadataProvider" /> s in the <see
    /// cref="N:MoEmbed.Providers" /> namespace.
    /// </summary>
    public static class MetadataServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="ServiceDescriptor" /> s of the <see cref="IMetadataProvider" /> in the
        /// <see cref="N:MoEmbed.Providers" /> namespace to the specified <see
        /// cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">
        /// The <see cref="IServiceCollection" /> to add <see cref="ServiceDescriptor" /> s.
        /// </param>
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

        /// <summary>
        /// Configures the specified <see cref="IServiceCollection" /> to use configuration root as
        /// known options types.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to configure.</param>
        /// <param name="configuration">The configuration to use as options.</param>
        public static void ConfigureMetadataProviderOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AmazonMetadataOptions>(configuration);
            services.Configure<ImgurMetadataOptions>(configuration);
        }
    }
}