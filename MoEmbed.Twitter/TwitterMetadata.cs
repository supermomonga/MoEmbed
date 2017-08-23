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
        public TwitterMetadata(Uri uri)
        {
            Uri = uri;
        }

        private static Regex regex = new Regex(@"https:\/\/twitter\.com\/(?<screenName>[^\/]+)\/status\/(?<statusId>\d+)");

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

        private Uri _Uri;

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri Uri
        {
            get
            {
                return _Uri;
            }
            set
            {
                var groups = regex.Match(value.ToString()).Groups;
                _TweetId = Int64.Parse(groups["statusId"].Value);
                _ScreenName = groups["screenName"].Value;
                _Uri = value;
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
        public override Task<EmbedData> FetchAsync()
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

            // Update Url to set right screenName
            Uri = new Uri(tweet.Url);
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
            };

            Data.ThumbnailUrl = new Uri(user.ProfileImageUrlHttps);
            Data.ThumbnailHeight = 48;
            Data.ThumbnailWidth = 48;

            foreach (var m in tweet.Media)
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
            }
            return Data;
        }
    }
}