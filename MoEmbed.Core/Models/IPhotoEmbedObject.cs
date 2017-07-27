using System;

namespace MoEmbed.Models
{
    /// <summary>
    /// This type is used for representing static photos.
    /// </summary>
    public interface IPhotoEmbedObject : IEmbedObject
    {
        /// <summary>
        /// Gets the source URL of the image.
        /// Consumers should be able to insert this URL into an &lt;img&gt; element.
        /// Only HTTP and HTTPS URLs are valid.
        /// </summary>
        Uri Url { get; }

        /// <summary>
        /// Gets the width in pixels of the image specified in the <see cref="ConsumerRequest.Url"/> parameter.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height in pixels of the image specified in the <see cref="ConsumerRequest.Url"/> parameter.
        /// </summary>
        int Height { get; }
    }
}