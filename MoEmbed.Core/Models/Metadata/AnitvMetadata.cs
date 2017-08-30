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

            Data.Type = EmbedDataTypes.MixedContent;

            var noText = nav.SelectSingleNode("//*[@class='movie-content-note']/h3/text()")?.Value?.Trim();
            if (noText != null)
            {
                var m = Regex.Match(noText, @"第\s*([0-9]{1,8})\s*話");

                if (m.Success)
                {
                    var no = int.Parse(m.Groups[1].Value);

                    var title = nav.SelectSingleNode("//*[@class='movie-content-note']/h2/text()")?.Value?.Trim();

                    if (title != null)
                    {
                        Data.Title = $"第{no}話 {title}";
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