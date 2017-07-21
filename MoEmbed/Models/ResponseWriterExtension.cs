using System;

namespace MoEmbed.Models
{
    public static class ResponseWriterExtension
    {
        public static void WritePropertyIfNeeded(this IResponseWriter writer ,string name, string value)
        {
            if(value != null)
            {
                writer.WriteProperty(name, value);
            }
        }
        public static void WritePropertyIfNeeded(this IResponseWriter writer ,string name, Uri value)
        {
            if(value != null)
            {
                writer.WriteProperty(name, value);
            }
        }
        public static void WritePropertyIfNeeded(this IResponseWriter writer ,string name, int? value)
        {
            if(value != null)
            {
                writer.WriteProperty(name, value.Value);
            }
        }
    }
}