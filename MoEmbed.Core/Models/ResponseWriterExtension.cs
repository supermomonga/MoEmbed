using System;
using System.Text.RegularExpressions;
using MoEmbed.Models.OEmbed;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Models
{
    public static class ResponseWriterExtension
    {
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

        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, string value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value);
            }
        }

        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, Uri value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value);
            }
        }

        public static void WritePropertyIfNeeded(this IResponseWriter writer, string name, int? value)
        {
            if (value != null)
            {
                writer.WriteProperty(name, value.Value);
            }
        }

        public static void WriteOEmbed(this IResponseWriter writer, IOEmbedData obj)
        {
            writer.WriteStartResponse();

            writer.WriteProperty(OEmbed.OEmbed.TYPE, obj.Type.ToString().ToLower());
            writer.WriteProperty(OEmbed.OEmbed.VERSION, "1.0");
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.TITLE, obj.Title);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.AUTHOR_NAME, obj.AuthorName);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.AUTHOR_URL, obj.AuthorUrl);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.PROVIDER_NAME, obj.ProviderName);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.PROVIDER_URL, obj.ProviderUrl);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.CACHE_AGE, obj.CacheAge);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.THUMBNAIL_URL, obj.ThumbnailUrl);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.THUMBNAIL_WIDTH, obj.ThumbnailWidth);
            writer.WritePropertyIfNeeded(OEmbed.OEmbed.THUMBNAIL_HEIGHT, obj.ThumbnailHeight);

            switch (obj.Type)
            {
                case OEmbed.Types.Photo:
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.URL, (obj as IPhotoOEmbedData)?.Url);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.WIDTH, (obj as IPhotoOEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.HEIGHT, (obj as IPhotoOEmbedData)?.Height);
                    break;
                case OEmbed.Types.Video:
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.HTML, (obj as IVideoOEmbedData)?.Html);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.WIDTH, (obj as IVideoOEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.HEIGHT, (obj as IVideoOEmbedData)?.Height);
                    break;
                case OEmbed.Types.Rich:
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.HTML, (obj as IRichOEmbedData)?.Html);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.WIDTH, (obj as IRichOEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.OEmbed.HEIGHT, (obj as IRichOEmbedData)?.Height);
                    break;
            }

            writer.WriteEndResponse();
        }

        public static void WriteEmbedData(this IResponseWriter writer, EmbedData obj)
        {
            writer.WriteStartResponse();

            writer.WritePropertyIfNeeded("title", obj.Title);
            writer.WritePropertyIfNeeded("author_name", obj.AuthorName);
            writer.WritePropertyIfNeeded("author_url", obj.AuthorUrl);
            writer.WritePropertyIfNeeded("provider_name", obj.ProviderName);
            writer.WritePropertyIfNeeded("provider_url", obj.ProviderUrl);
            writer.WritePropertyIfNeeded("cache_age", obj.CacheAge);
            writer.WritePropertyIfNeeded("thumbnail_url", obj.ThumbnailUrl);
            writer.WritePropertyIfNeeded("thumbnail_width", obj.ThumbnailWidth);
            writer.WritePropertyIfNeeded("thumbnail_height", obj.ThumbnailHeight);

            writer.WriteEndResponse();
        }
    }
}
