using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Tweetinvi;
using Tweetinvi.Models;

namespace MoEmbed.Models
{
    [Serializable]
    public class TwitterEmbedObject : Metadata, IRichEmbedObject
    {
        public TwitterEmbedObject(string uri, ITwitterCredentials credentials)
            : this(new Uri(uri), credentials)
        {
        }

        public TwitterEmbedObject(Uri uri, ITwitterCredentials credentials)
        {
            Tweetinvi.Auth.SetCredentials(credentials);
            Uri = uri;
        }

        private static Regex regex = new Regex(@"https:\/\/twitter\.com\/(?<screenName>[^\/]+)\/status\/(?<statusId>\d+)");

        private string _ScreenName;
        /// <summary>
        /// Gets the tweet's screen name.
        /// </summary>
        [DefaultValue(null)]
        public string ScreenName {
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
        public long TweetId {
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
        public Uri Uri {
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
        /// Gets or sets the URL the <see cref="Uri" /> moved to.
        /// </summary>
        [DefaultValue(null)]
        public Uri MovedTo { get; set; }

        #region IEmbedObject Properties

        /// <inheritdoc />
        public override Types Type => Types.Link;

        string IEmbedObject.Type
            => TypeString;

        /// <summary>
        /// Gets or sets a text title, describing the resource.
        /// </summary>
        [DefaultValue(null)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets a URL for the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public Uri AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the url of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public Uri ProviderUrl { get; set; }

        /// <summary>
        /// Gets or sets the suggested cache lifetime for this resource, in seconds. Consumers may choose to use this value or not.
        /// </summary>
        [DefaultValue(null)]
        public int? CacheAge { get; set; }

        /// <summary>
        /// Gets or sets a URL to a thumbnail image representing the resource.
        /// </summary>
        /// <remarks>
        /// The thumbnail must respect any <see cref="ConsumerRequest.MaxWidth"/> and <see cref="ConsumerRequest.MaxHeight"/> parameters.
        /// If this parameter is present, <see cref="ThumbnailWidth" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public Uri ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the width of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailWidth" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailHeight { get; set; }

        /// <summary>
        /// Gets or sets the HTML of the content.
        /// </summary>
        [DefaultValue(null)]
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the width of the HTML content.
        /// </summary>
        [DefaultValue(null)]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the HTML content.
        /// </summary>
        [DefaultValue(null)]
        public int Height { get; set; }

        #endregion IEmbedObject Properties

        protected override void WriteProperties(IResponseWriter writer)
        {
            writer.WriteDefaultProperties((IRichEmbedObject)this);
        }

        /// <inheritdoc />
        public async override Task FetchAsync()
        {
            var tweet = Tweet.GetTweet(TweetId);
            var user = User.GetUserFromScreenName(ScreenName);

            AuthorName = $"{ user.Name }(@{ ScreenName })";
            AuthorUrl = new Uri($"https://twitter.com/{ ScreenName }/");

            // TODO: Insert Fav, RT
            Title = AuthorName;

            // TODO: Insert media
            Html = tweet.FullText;

            // TODO: Use request parameter
            Width = 400;
            Height = 150;

            ProviderName = "Twitter";
            ProviderUrl = new Uri("https://twitter.com/");
        }
    }
}














