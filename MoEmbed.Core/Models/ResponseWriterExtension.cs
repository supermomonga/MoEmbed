using System;
using System.Text.RegularExpressions;

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

        public static void WriteOEmbed(this IResponseWriter writer, IEmbedData obj)
        {
            writer.WriteStartResponse();

            writer.WriteProperty(OEmbed.TYPE, obj.Type.ToString().ToLower());
            writer.WriteProperty(OEmbed.VERSION, "1.0");
            writer.WritePropertyIfNeeded(OEmbed.TITLE, obj.Title);
            writer.WritePropertyIfNeeded(OEmbed.AUTHOR_NAME, obj.AuthorName);
            writer.WritePropertyIfNeeded(OEmbed.AUTHOR_URL, obj.AuthorUrl);
            writer.WritePropertyIfNeeded(OEmbed.PROVIDER_NAME, obj.ProviderName);
            writer.WritePropertyIfNeeded(OEmbed.PROVIDER_URL, obj.ProviderUrl);
            writer.WritePropertyIfNeeded(OEmbed.CACHE_AGE, obj.CacheAge);
            writer.WritePropertyIfNeeded(OEmbed.THUMBNAIL_URL, obj.ThumbnailUrl);
            writer.WritePropertyIfNeeded(OEmbed.THUMBNAIL_WIDTH, obj.ThumbnailWidth);
            writer.WritePropertyIfNeeded(OEmbed.THUMBNAIL_HEIGHT, obj.ThumbnailHeight);

            switch (obj.Type)
            {
                case Types.Photo:
                    writer.WritePropertyIfNeeded(OEmbed.URL, (obj as IPhotoEmbedData)?.Url);
                    writer.WritePropertyIfNeeded(OEmbed.WIDTH, (obj as IPhotoEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.HEIGHT, (obj as IPhotoEmbedData)?.Height);
                    break;
                case Types.Video:
                    writer.WritePropertyIfNeeded(OEmbed.URL, (obj as IVideoEmbedData)?.Html);
                    writer.WritePropertyIfNeeded(OEmbed.WIDTH, (obj as IVideoEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.HEIGHT, (obj as IVideoEmbedData)?.Height);
                    break;
                case Types.Rich:
                    writer.WritePropertyIfNeeded(OEmbed.URL, (obj as IRichEmbedData)?.Html);
                    writer.WritePropertyIfNeeded(OEmbed.WIDTH, (obj as IRichEmbedData)?.Width);
                    writer.WritePropertyIfNeeded(OEmbed.HEIGHT, (obj as IRichEmbedData)?.Height);
                    break;
            }

            writer.WriteEndResponse();
        }
    }
}