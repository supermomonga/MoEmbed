using System.ComponentModel;
using Newtonsoft.Json;

namespace MoEmbed.Models.Imgur
{
    /// <summary>
    /// Represents a responce from imgur.com
    /// </summary>
    public sealed class ImgurResponse<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets a value indicating whether the request was succeeded.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a HTTP status code.
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets a response data.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("data")]
        public T Data { get; set; }
    }

}