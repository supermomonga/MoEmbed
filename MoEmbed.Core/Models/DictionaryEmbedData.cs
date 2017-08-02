using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoEmbed.Models
{
    [Serializable]
    public class DictionaryEmbedData : IEmbedData, IPhotoEmbedData, IVideoEmbedData, IRichEmbedData
    {
        // TODO: Add interfaces to Acess as dictionary

        private Dictionary<string, object> _Values;

        public DictionaryEmbedData()
        {
            _Values = new Dictionary<string, object>();
        }

        internal DictionaryEmbedData(Dictionary<string, object> values)
        {
            _Values = values;
        }

        [DefaultValue(Types.Link)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            set
            {
                switch (value)
                {
                    case Types.Link:
                        _Values[OEmbed.TYPE] = OEmbed.LINK_TYPE;
                        break;

                    case Types.Photo:
                        _Values[OEmbed.TYPE] = OEmbed.PHOTO_TYPE;
                        break;

                    case Types.Video:
                        _Values[OEmbed.TYPE] = OEmbed.VIDEO_TYPE;
                        break;

                    case Types.Rich:
                        _Values[OEmbed.TYPE] = OEmbed.RICH_TYPE;
                        break;

                    default:
                        _Values[OEmbed.TYPE] = value.ToString("G").ToLowerInvariant();
                        break;
                }
            }
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get => _Values.TryGetValue(OEmbed.TITLE, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.TITLE] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AuthorName
        {
            get => _Values.TryGetValue(OEmbed.AUTHOR_NAME, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.AUTHOR_NAME] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Uri AuthorUrl
        {
            get => _Values.TryGetValue(OEmbed.AUTHOR_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.AUTHOR_URL] = value?.ToString();
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProviderName
        {
            get => _Values.TryGetValue(OEmbed.PROVIDER_NAME, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.PROVIDER_NAME] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Uri ProviderUrl
        {
            get => _Values.TryGetValue(OEmbed.PROVIDER_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.PROVIDER_URL] = value?.ToString();
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CacheAge
        {
            get => _Values.TryGetValue(OEmbed.CACHE_AGE, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.CACHE_AGE] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Uri ThumbnailUrl
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.THUMBNAIL_URL] = value?.ToString();
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ThumbnailWidth
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.THUMBNAIL_WIDTH] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ThumbnailHeight
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.THUMBNAIL_HEIGHT] = value;
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Uri Url
        {
            get => _Values.TryGetValue(OEmbed.URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.URL] = value?.ToString();
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Html
        {
            get => _Values.TryGetValue(OEmbed.HTML, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.HTML] = value;
        }

        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Width
        {
            get => _Values.TryGetValue(OEmbed.WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;
            set => _Values[OEmbed.WIDTH] = value;
        }

        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Height
        {
            get => _Values.TryGetValue(OEmbed.HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;
            set => _Values[OEmbed.HEIGHT] = value;
        }

        public string Json
        {
            // HACK: avoiding Portable.Xaml 0.16.0 bug
            get => " " + ToString();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Values.Clear();
                }
                else
                {
                    _Values = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
                }
            }
        }

        public Dictionary<string, object> ToDictionary()
            => _Values.ToDictionary(kv => kv.Key, kv => kv.Value);

        /// <inheritdoc />
        public override string ToString()
        {
            return JObject.FromObject(_Values).ToString();
        }
    }
}