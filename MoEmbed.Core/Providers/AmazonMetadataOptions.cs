namespace MoEmbed.Providers
{
    /// <summary>
    /// Represents options of the <see cref="AmazonMetadataProvider" />.
    /// </summary>
    public sealed class AmazonMetadataOptions
    {
        /// <summary>
        /// Gets or sets root accessr key for the AWS.
        /// </summary>
        public string AWSAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets root secret key for the AWS.
        /// </summary>
        public string AWSSecretKey { get; set; }

        /// <summary>
        /// Gets or sets an amazon associate program tag.
        /// </summary>
        public string AmazonAssociateTag { get; set; }
    }
}