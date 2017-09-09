using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoEmbed.Providers;

namespace MoEmbed.Twitter
{
    /// <summary>
    /// Provides extension methods to configure <see cref="IMetadataProvider" /> s in the <see
    /// cref="N:MoEmbed.Twitter" /> namespace.
    /// </summary>
    public static class TwitterMetadataServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="ServiceDescriptor" /> s of the <see cref="IMetadataProvider" /> in the
        /// <see cref="N:MoEmbed.Twitter" /> namespace to the specified <see
        /// cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">
        /// The <see cref="IServiceCollection" /> to add <see cref="ServiceDescriptor" /> s.
        /// </param>
        public static void AddTwitterMetadataProviders(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IMetadataProvider), typeof(TwitterMetadataProvider), ServiceLifetime.Singleton));
        }

        /// <summary>
        /// Configures the specified <see cref="IServiceCollection" /> to use configuration root as
        /// known options types.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to configure.</param>
        /// <param name="configuration">The configuration to use as options.</param>
        public static void ConfigureTwitterMetadataProviderOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TwitterMetadataOptions>(configuration);
        }
    }
}