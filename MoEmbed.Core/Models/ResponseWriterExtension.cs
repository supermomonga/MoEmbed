using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoEmbed.Models
{
    /// <summary>
    /// Provides methods to extend <see cref="IResponseWriter" />.
    /// </summary>
    public static class ResponseWriterExtension
    {
        /// <summary>
        /// Writes a property to the specified writer if the value is not null.
        /// </summary>
        /// <param name="writer">The writer to write.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, object value)
        {
            if (value != null)
            {
                var t = value.GetType();

                if (t == typeof(bool))
                {
                    writer.WriteProperty(name, (bool)value);
                }
                else if (Regex.IsMatch(t.FullName, "^System.(U?Int(16|32|64)|S?Byte|Single|Double|Decimal)$"))
                {
                    writer.WriteProperty(name, ((IConvertible)value).ToDouble(null));
                }
                else
                {
                    writer.WriteProperty(name, value.ToString());
                }
            }
        }

        /// <summary>
        /// Writes a string property to the specified writer if the value is not null.
        /// </summary>
        /// <param name="writer">The writer to write.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, string value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value);
            }
        }

        /// <summary>
        /// Writes a URL property to the specified writer if the value is not null.
        /// </summary>
        /// <param name="writer">The writer to write.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, Uri value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value);
            }
        }

        /// <summary>
        /// Writes a integral property to the specified writer if the value is not null.
        /// </summary>
        /// <param name="writer">The writer to write.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, int? value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value.Value);
            }
        }

        /// <summary>
        /// Writes a EmbedData to the specified writer.
        /// </summary>
        /// <param name="writer">The writer to write.</param>
        /// <param name="obj">The <see cref="EmbedData" />.</param>
        /// <param name="hash">The URL hash to append.</param>
        public static async Task WriteEmbedDataAsync(this IResponseWriter writer, EmbedData obj, string hash = null)
        {
            writer.WriteStartResponse();

            writer.WritePropertyIfNeeded("type", obj.Type);
            writer.WritePropertyIfNeeded("url", obj.Url + hash);
            writer.WritePropertyIfNeeded("title", obj.Title);
            writer.WritePropertyIfNeeded("description", obj.Description);
            writer.WritePropertyIfNeeded("author_name", obj.AuthorName);
            writer.WritePropertyIfNeeded("author_url", obj.AuthorUrl);
            writer.WritePropertyIfNeeded("html", obj.Html);
            writer.WritePropertyIfNeeded("provider_name", obj.ProviderName);
            writer.WritePropertyIfNeeded("provider_url", obj.ProviderUrl);
            writer.WritePropertyIfNeeded("cache_age", obj.CacheAge);
            writer.WriteStartObjectProperty("metadata_image");
            writer.WritePropertyIfNeeded("type", obj.MetadataImage?.Type);
            writer.WritePropertyIfNeeded("restriction_policy", obj.MetadataImage?.RestrictionPolicy);
            writer.WritePropertyIfNeeded("raw_url", obj.MetadataImage?.RawUrl);
            writer.WritePropertyIfNeeded("location", obj.MetadataImage?.Location);
            writer.WriteStartObjectProperty("thumbnail");
            writer.WritePropertyIfNeeded("url", obj.MetadataImage?.Thumbnail?.Url);
            writer.WritePropertyIfNeeded("width", obj.MetadataImage?.Thumbnail?.Width);
            writer.WritePropertyIfNeeded("height", obj.MetadataImage?.Thumbnail?.Height);
            writer.WriteEndObjectProperty();
            writer.WriteEndObjectProperty();
            writer.WritePropertyIfNeeded("restriction_policy", obj.RestrictionPolicy);

            if (obj.Medias.Count > 0)
            {
                writer.WriteStartArrayProperty("medias");
                foreach (var media in obj.Medias)
                {
                    writer.WriteStartObject("media");
                    writer.WriteProperty("type", media.Type.ToString());
                    if (media.Thumbnail != null)
                    {
                        writer.WriteStartObjectProperty("thumbnail");
                        writer.WritePropertyIfNeeded("url", media.Thumbnail.Url);
                        writer.WritePropertyIfNeeded("width", media.Thumbnail.Width);
                        writer.WritePropertyIfNeeded("height", media.Thumbnail.Height);
                        writer.WriteEndObjectProperty();
                    }
                    writer.WritePropertyIfNeeded("raw_url", media.RawUrl);
                    writer.WritePropertyIfNeeded("location", media.Location);
                    writer.WritePropertyIfNeeded("restriction_policy", media.RestrictionPolicy);
                    writer.WriteEndObject();
                }
                writer.WriteEndArrayProperty();
            }

            await writer.WriteEndResponseAsync();
        }
    }
}