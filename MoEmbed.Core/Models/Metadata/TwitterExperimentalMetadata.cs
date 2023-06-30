using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using MoEmbed.Models.TweetExperimental;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of the Twitter.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class TwitterExperimentalMetadata : Metadata
    {
        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        /// <summary>
        /// Tweet url
        /// </summary>
        [DefaultValue(null)]
        public string Url { get; set; }

        /// <summary>
        /// Twitter status id
        /// </summary>
        [DefaultValue(null)]
        public string StatusId { get; set; }

        /// <inheritdoc/>
        public override async Task<EmbedData> FetchAsync(RequestContext context)
        {
            if (string.IsNullOrEmpty(StatusId)) return null;

            var req = new HttpRequestMessage(HttpMethod.Get, $"https://cdn.syndication.twimg.com/tweet-result?id={StatusId}");
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var res = await context.Service.HttpClient.SendAsync(req).ConfigureAwait(false);

            res.EnsureSuccessStatusCode();

            var tweet = JsonSerializer.Deserialize<Tweet>(res.Content.ReadAsStream(), new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

            return new EmbedData()
            {
                Url = Url,
                MetadataImage = new Media
                {
                    Thumbnail = new ImageInfo
                    {
                        Url = tweet.User.ProfileImageUrlHttps,
                        Height = 48,
                        Width = 48,
                    },
                    RawUrl = tweet.User.ProfileImageUrlHttps,
                    Location = Url,
                    RestrictionPolicy = RestrictionPolicies.Safe
                },
                Title = tweet.User.Name,
                Description = tweet.Text,
                Medias = tweet.MediaDetails.Select(ToMedia).ToList(),
                RestrictionPolicy = tweet.PossiblySensitive ? RestrictionPolicies.Restricted : RestrictionPolicies.Safe,

                ProviderName = "Twitter",
                ProviderUrl = "https://twitter.com/",
            };
        }

        private static Media ToMedia(MediaDetail m) => new()
        {
            Type = MediaTypeFromString(m.Type),
            Thumbnail = new()
            {
                Url = $"{m.MediaUrlHttps}:thumb",
                Width = 150,
                Height = 150,
            },
            RawUrl = m.MediaUrlHttps,
            Location = m.ExpandedUrl,
        };

        private static MediaTypes MediaTypeFromString(string s) => s switch
        {
            "photo" => MediaTypes.Image,
            "video" or "animated_gif" => MediaTypes.Video,
            _ => throw new NotImplementedException()
        };
    }
}