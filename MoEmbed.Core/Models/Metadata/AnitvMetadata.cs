using System;
using HtmlAgilityPack;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="https://ani.tv"/>.
    /// </summary>
    [Serializable]
    public class AnitvMetadata : UnknownMetadata
    {
        /// <inheritdoc />
        protected override HtmlDocument LoadHtml(string html)
        {
            var hd = base.LoadHtml(html);
            var nav = hd.CreateNavigator();

            var desc = nav.SelectSingleNode("//*[@class='mcd-text']/text()")?.Value?.Trim();

            if (!string.IsNullOrEmpty(desc))
            {
                Data.Description = desc;
            }

            return hd;
        }
    }
}