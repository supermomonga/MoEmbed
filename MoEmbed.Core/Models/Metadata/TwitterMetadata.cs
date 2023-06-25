using Portable.Xaml.Markup;

using System;
using System.Collections.Generic;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the URL of the nicotweet.jp.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class TwitterMetadata : OEmbedProxyMetadata
    {
        /// <inheritdoc/>
        protected internal override EmbedData CreateEmbedData(Dictionary<string, object> values)
        {
            var data = base.CreateEmbedData(values);
            data.Title = data.AuthorName ?? "Twitter";


            var parser = new AngleSharp.Html.Parser.HtmlParser();
            using var doc = parser.ParseDocument(data.Html);
            data.Description = doc.QuerySelector("blockquote p").TextContent;

            return data;
        }
    }
}