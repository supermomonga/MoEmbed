using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
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

        internal static readonly Regex regex = new Regex(@"https:\/\/(mobile\.)?twitter\.com\/(?<screenName>[^\/]+)\/status\/(?<statusId>\d+)");

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
                _Url = value;
                if (value != null)
                {
                    var m = regex.Match(value.ToString());
                    if (m.Success)
                    {
                        var groups = m.Groups;
                        _TweetId = Int64.Parse(groups["statusId"].Value);
                        _ScreenName = groups["screenName"].Value;
                        return;
                    }
                }
                _TweetId = 0;
                _ScreenName = null;
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
            if (TweetId <= 0)
            {
                return null;
            }
            var tweet = Tweet.GetTweet(TweetId);
            var extendedTweet = tweet.ExtendedTweet;
            // Update Url to set right screenName
            Url = new Uri(tweet.Url);
            var user = User.GetUserFromScreenName(ScreenName);

            var authorName = HtmlEntity.DeEntitize($"{ user.Name }(@{ ScreenName })");

            var description = tweet.FullText != null
                                        && tweet.DisplayTextRange?.Length == 2
                                            ? tweet.FullText.Substring(tweet.DisplayTextRange[0], tweet.DisplayTextRange[1] - tweet.DisplayTextRange[0])
                                : tweet.Prefix != null ? $"{tweet.Prefix} {tweet.Text}"
                                : tweet.Text;

            Data = new EmbedData()
            {
                Url = Url,
                AuthorName = authorName,
                AuthorUrl = new Uri($"https://twitter.com/{ ScreenName }/"),

                // TODO: Insert Fav, RT
                Title = authorName,

                // TODO: Insert media
                Description = HtmlEntity.DeEntitize(description),

                ProviderName = "Twitter",
                ProviderUrl = new Uri("https://twitter.com/"),

                Nsfw = !!tweet.PossiblySensitive,
            };

            Data.Thumbnail = new Media
            {
                Thumbnail = new ImageInfo
                {
                    Url = new Uri(user.ProfileImageUrlHttps),
                    Height = 48,
                    Width = 48,
                },
                RawUrl = new Uri(user.ProfileImageUrlHttps),
                Location = Url,
                Nsfw = false
            };

            foreach (var m in (extendedTweet?.ExtendedEntities ?? tweet.Entities).Medias)
            {
                // https://dev.twitter.com/overview/api/entities-in-twitter-objects#media
                if (m.MediaType == "photo")
                {
                    var media = new Media
                    {
                        Type = MediaTypes.Image,
                        Thumbnail = new ImageInfo
                        {
                            Url = new Uri($"{m.MediaURLHttps}:thumb"),
                            // Thumbnail size is always 150x150
                            Width = 150,
                            Height = 150,
                        },
                        RawUrl = new Uri(m.MediaURLHttps),
                        Location = new Uri(m.ExpandedURL),
                        Nsfw = Data.Nsfw,
                    };
                    Data.Medias.Add(media);
                }
                else if (m.MediaType == "animated_gif" || m.MediaType == "video")
                {
                    var media = new Media
                    {
                        Type = MediaTypes.Video,
                        Thumbnail = new ImageInfo
                        {
                            Url = new Uri($"{m.MediaURLHttps}:thumb"),
                            // Thumbnail size is always 150x150
                            Width = 150,
                            Height = 150,
                        },
                        RawUrl = new Uri(m.MediaURLHttps),
                        Location = new Uri(m.ExpandedURL),
                    };
                    Data.Medias.Add(media);
                }
            }
            return Data;
        }
    }
}