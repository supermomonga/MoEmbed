using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tweetinvi;

namespace MoEmbed.Models
{
    [Serializable]
    public class TwitterMetadata : Metadata.Metadata
    {
        /// <summary>
        /// Initializes a new instaince of the <see cref="TwitterMetadata" /> class.
        /// </summary>
        public TwitterMetadata()
        {
        }

        internal TwitterMetadata(Uri url)
        {
            Url = url;
        }

        internal static readonly Regex regex = new Regex(@"https:\/\/twitter\.com\/(?<screenName>[^\/]+)\/status\/(?<statusId>\d+)");

        [NonSerialized]
        private string _ScreenName;

        /// <summary>
        /// Gets the tweet's screen name.
        /// </summary>
        [DefaultValue(null)]
        public string ScreenName
        {
            get
            {
                return _ScreenName;
            }
        }

        private long _TweetId;

        /// <summary>
        /// Gets the tweet ID.
        /// </summary>
        [DefaultValue(null)]
        public long TweetId
        {
            get
            {
                return _TweetId;
            }
        }

        [NonSerialized]
        private Uri _Url;

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri Url
        {
            get
            {
                return _Url;
            }
            set
            {
                var groups = regex.Match(value.ToString()).Groups;
                _TweetId = Int64.Parse(groups["statusId"].Value);
                _ScreenName = groups["screenName"].Value;
                _Url = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        [NonSerialized]
        private Task<EmbedData> _FetchTask;

        /// <inheritdoc />
        public override Task<EmbedData> FetchAsync(RequestContext request)
        {
            lock (this)
            {
                if (_FetchTask == null)
                {
                    if (Data != null)
                    {
                        _FetchTask = Task.FromResult<EmbedData>(Data);
                    }
                    else
                    {
                        _FetchTask = Task.Run((Func<EmbedData>)FetchCore);
                        _FetchTask.ConfigureAwait(false);
                    }
                }
                return _FetchTask;
            }
        }

        private EmbedData FetchCore()
        {
            var tweet = Tweet.GetTweet(TweetId);
            var extendedTweet = tweet.ExtendedTweet;
            // Update Url to set right screenName
            Url = new Uri(tweet.Url);
            var user = User.GetUserFromScreenName(ScreenName);

            Data = new EmbedData()
            {
                AuthorName = $"{ user.Name }(@{ ScreenName })",
                AuthorUrl = new Uri($"https://twitter.com/{ ScreenName }/"),

                // TODO: Insert Fav, RT
                Title = $"{ user.Name }(@{ ScreenName })",

                // TODO: Insert media
                Description = tweet.FullText,

                ProviderName = "Twitter",
                ProviderUrl = new Uri("https://twitter.com/"),

                Nsfw = !!tweet.PossiblySensitive,
            };

            Data.ThumbnailUrl = new Uri(user.ProfileImageUrlHttps);
            Data.ThumbnailHeight = 48;
            Data.ThumbnailWidth = 48;

            foreach (var m in (extendedTweet?.ExtendedEntities ?? tweet.Entities).Medias)
            {
                // https://dev.twitter.com/overview/api/entities-in-twitter-objects#media
                if (m.MediaType == "photo")
                {
                    var media = new Media
                    {
                        Type = MediaTypes.Image,
                        ThumbnailUri = new Uri($"{m.MediaURLHttps}:thumb"),
                        RawUri = new Uri(m.MediaURLHttps),
                        Location = new Uri(m.ExpandedURL),
                    };
                    Data.Medias.Add(media);
                }
                else if (m.MediaType == "animated_gif" || m.MediaType == "video")
                {
                    var media = new Media
                    {
                        Type = MediaTypes.Video,
                        ThumbnailUri = new Uri($"{m.MediaURLHttps}:thumb"),
                        RawUri = new Uri(m.MediaURLHttps),
                        Location = new Uri(m.ExpandedURL),
                    };
                    Data.Medias.Add(media);
                }
            }
            return Data;
        }
    }
}