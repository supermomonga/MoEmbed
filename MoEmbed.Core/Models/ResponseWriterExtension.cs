using System;

namespace MoEmbed.Models
{
    public static class ResponseWriterExtension
    {
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

        public static void WriteCommonProperties(this IResponseWriter writer, IEmbedObject obj)
        {
            writer.WriteProperty("type", obj.Type);
            writer.WriteProperty("version", obj.Version);
            writer.WritePropertyIfNeeded("title", obj.Title);
            writer.WritePropertyIfNeeded("author_name", obj.AuthorName);
            writer.WritePropertyIfNeeded("author_url", obj.AuthorUrl);
            writer.WritePropertyIfNeeded("provider_name", obj.ProviderName);
            writer.WritePropertyIfNeeded("provider_url", obj.ProviderUrl);
            writer.WritePropertyIfNeeded("cache_age", obj.CacheAge);
            writer.WritePropertyIfNeeded("thumbnail_url", obj.ThumbnailUrl);
            writer.WritePropertyIfNeeded("thumbnail_width", obj.ThumbnailWidth);
            writer.WritePropertyIfNeeded("thumbnail_height", obj.ThumbnailHeight);
        }

        public static void WriteDefaultProperties(this IResponseWriter writer, IPhotoEmbedObject obj)
        {
            writer.WriteCommonProperties(obj);
            writer.WritePropertyIfNeeded("url", obj.Url);
            writer.WritePropertyIfNeeded("width", obj.Width);
            writer.WritePropertyIfNeeded("height", obj.Height);
        }

        public static void WriteDefaultProperties(this IResponseWriter writer, IVideoEmbedObject obj)
        {
            writer.WriteCommonProperties(obj);
            writer.WritePropertyIfNeeded("html", obj.Html);
            writer.WritePropertyIfNeeded("width", obj.Width);
            writer.WritePropertyIfNeeded("height", obj.Height);
        }

        public static void WriteDefaultProperties(this IResponseWriter writer, ILinkEmbedObject obj)
        {
            writer.WriteCommonProperties(obj);
        }

        public static void WriteDefaultProperties(this IResponseWriter writer, IRichEmbedObject obj)
        {
            writer.WriteCommonProperties(obj);
            writer.WritePropertyIfNeeded("html", obj.Html);
            writer.WritePropertyIfNeeded("width", obj.Width);
            writer.WritePropertyIfNeeded("height", obj.Height);
        }
    }
}