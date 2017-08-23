using System;
using HtmlAgilityPack;

namespace MoEmbed
{
    internal static class StringHelper
    {
        public static string DeEntitize(this string text)
            => string.IsNullOrEmpty(text) ? null : HtmlEntity.DeEntitize(text);

        public static Uri ToUri(this string urlString)
            => string.IsNullOrEmpty(urlString) ? null : new Uri(urlString);
    }
}