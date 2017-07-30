using System;
using System.Collections.Generic;

namespace MoEmbed.Models
{
    [Serializable]
    public class DictionaryEmbedData : IEmbedData, IPhotoEmbedData, IVideoEmbedData, IRichEmbedData
    {
        // TODO: Add interfaces to Addcess as dictionary

        private readonly Dictionary<string, object> _Values;

        public DictionaryEmbedData()
        {
            _Values = new Dictionary<string, object>();
        }

        internal DictionaryEmbedData(Dictionary<string, object> values)
        {
            _Values = values;
        }

        public Types Type
        {
            get
            {
                if (_Values != null && _Values.TryGetValue(OEmbed.TYPE, out object t))
                {
                    switch (t)
                    {
                        case OEmbed.LINK_TYPE:
                            return Types.Link;

                        case OEmbed.PHOTO_TYPE:
                            return Types.Photo;

                        case OEmbed.VIDEO_TYPE:
                            return Types.Video;

                        case OEmbed.RICH_TYPE:
                            return Types.Rich;
                    }
                }
                return Types.Link;
            }
        }

        public string Title
            => _Values.TryGetValue(OEmbed.TITLE, out object s) ? s?.ToString() : null;

        public string AuthorName
            => _Values.TryGetValue(OEmbed.AUTHOR_NAME, out object s) ? s?.ToString() : null;

        public Uri AuthorUrl
            => _Values.TryGetValue(OEmbed.AUTHOR_URL, out object s) ? new Uri(s?.ToString()) : null;

        public string ProviderName
            => _Values.TryGetValue(OEmbed.PROVIDER_NAME, out object s) ? s?.ToString() : null;

        public Uri ProviderUrl
            => _Values.TryGetValue(OEmbed.PROVIDER_URL, out object s) ? new Uri(s?.ToString()) : null;

        public int? CacheAge
            => _Values.TryGetValue(OEmbed.CACHE_AGE, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;

        public Uri ThumbnailUrl
            => _Values.TryGetValue(OEmbed.THUMBNAIL_URL, out object s) ? new Uri(s?.ToString()) : null;

        public int? ThumbnailWidth
            => _Values.TryGetValue(OEmbed.THUMBNAIL_WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;

        public int? ThumbnailHeight
            => _Values.TryGetValue(OEmbed.THUMBNAIL_HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;

        public Uri Url
            => _Values.TryGetValue(OEmbed.URL, out object s) ? new Uri(s?.ToString()) : null;

        public string Html
            => _Values.TryGetValue(OEmbed.HTML, out object s) ? s?.ToString() : null;

        public int Width
            => _Values.TryGetValue(OEmbed.WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;

        public int Height
            => _Values.TryGetValue(OEmbed.HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;
    }
}