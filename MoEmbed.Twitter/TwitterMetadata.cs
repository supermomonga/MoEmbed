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
        private string _Url;

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public string Url
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
                    var m = regex.Match(value);
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
            Url = tweet.Url;
            var user = User.GetUserFromScreenName(ScreenName);

            var authorName = HtmlEntity.DeEntitize($"{ user.Name }(@{ ScreenName })");

            string description;
            if (tweet.FullText != null
                && tweet.DisplayTextRange?.Length == 2)
            {
                var length = tweet.DisplayTextRange[1];
                for (var i = 0; i < length; i++)
                {
                    if (char.IsHighSurrogate(tweet.FullText[i]))
                    {
                        length++;
                    }
                }
                description = tweet.FullText.Substring(0, length);
            }
            else
            {
                description = tweet.Prefix != null ? $"{tweet.Prefix} {tweet.Text}" : tweet.Text;
            }

            Data = new EmbedData()
            {
                Url = Url,
                AuthorName = authorName,
                AuthorUrl = $"https://twitter.com/{ ScreenName }/",

                // TODO: Insert Fav, RT
                Title = authorName,

                // TODO: Insert media
                Description = HtmlEntity.DeEntitize(description),

                ProviderName = "Twitter",
                ProviderUrl = "https://twitter.com/",
            };
            if (!!tweet.PossiblySensitive)
            {
                Data.RestrictionPolicy = RestrictionPolicies.Restricted;
            }

            Data.MetadataImage = new Media
            {
                Thumbnail = new ImageInfo
                {
                    Url = user.ProfileImageUrlHttps,
                    Height = 48,
                    Width = 48,
                },
                RawUrl = user.ProfileImageUrlHttps,
                Location = Url,
                RestrictionPolicy = RestrictionPolicies.Safe
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
                            Url = $"{m.MediaURLHttps}:thumb",
                            // Thumbnail size is always 150x150
                            Width = 150,
                            Height = 150,
                        },
                        RawUrl = m.MediaURLHttps,
                        Location = m.ExpandedURL,
                        RestrictionPolicy = Data.RestrictionPolicy,
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
                            Url = $"{m.MediaURLHttps}:thumb",
                            // Thumbnail size is always 150x150
                            Width = 150,
                            Height = 150,
                        },
                        RawUrl = m.MediaURLHttps,
                        Location = m.ExpandedURL,
                    };
                    Data.Medias.Add(media);
                }
            }
            return Data;
        }
    }
}