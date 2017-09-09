namespace MoEmbed.Twitter
{
    /// <summary>
    /// Represents options of the <see cref="TwitterMetadataProvider" />.
    /// </summary>
    public class TwitterMetadataOptions
    {
        /// <summary>
        /// Gets or sets Consumer Key for the Twitter API.
        /// </summary>
        public string TwitterConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets Consumer Secret for the Twitter API.
        /// </summary>
        public string TwitterConsumerSecret { get; set; }
    }
}