using System;
using System.Text.RegularExpressions;
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

            Data.Type = EmbedDataTypes.SingleVideo;

            var noText = nav.SelectSingleNode("//*[@class='movie-content-note']/h3/text()")?.Value?.Trim();
            if (noText != null)
            {
                var m = Regex.Match(noText, @"‘æ\s*([0-9]{1,8})\s*˜b");

                if (m.Success)
                {
                    var no = int.Parse(m.Groups[1].Value);

                    var title = nav.SelectSingleNode("//*[@class='movie-content-note']/h2/text()")?.Value?.Trim();

                    if (title != null)
                    {
                        Data.Title = $"‘æ{no}˜b {title}";
                    }
                }
            }

            var desc = nav.SelectSingleNode("//*[@class='mcd-text']/text()")?.Value?.Trim();

            if (!string.IsNullOrEmpty(desc))
            {
                Data.Description = desc;
            }

            return hd;
        }
    }
}