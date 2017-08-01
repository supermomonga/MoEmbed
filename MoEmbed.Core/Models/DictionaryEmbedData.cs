using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MoEmbed.Models
{
    [Serializable]
    public class DictionaryEmbedData : IEmbedData, IPhotoEmbedData, IVideoEmbedData, IRichEmbedData, IXmlSerializable
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

        public string Title
        {
            get => _Values.TryGetValue(OEmbed.TITLE, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.TITLE] = value;
        }

        public string AuthorName
        {
            get => _Values.TryGetValue(OEmbed.AUTHOR_NAME, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.AUTHOR_NAME] = value;
        }

        public Uri AuthorUrl
        {
            get => _Values.TryGetValue(OEmbed.AUTHOR_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.AUTHOR_URL] = value?.ToString();
        }

        public string ProviderName
        {
            get => _Values.TryGetValue(OEmbed.PROVIDER_NAME, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.PROVIDER_NAME] = value;
        }

        public Uri ProviderUrl
        {
            get => _Values.TryGetValue(OEmbed.PROVIDER_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.PROVIDER_URL] = value?.ToString();
        }

        public int? CacheAge
        {
            get => _Values.TryGetValue(OEmbed.CACHE_AGE, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.CACHE_AGE] = value;
        }

        public Uri ThumbnailUrl
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.THUMBNAIL_URL] = value?.ToString();
        }

        public int? ThumbnailWidth
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.THUMBNAIL_WIDTH] = value;
        }

        public int? ThumbnailHeight
        {
            get => _Values.TryGetValue(OEmbed.THUMBNAIL_HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) : null;
            set => _Values[OEmbed.THUMBNAIL_HEIGHT] = value;
        }

        public Uri Url
        {
            get => _Values.TryGetValue(OEmbed.URL, out object s) ? new Uri(s?.ToString()) : null;
            set => _Values[OEmbed.URL] = value?.ToString();
        }

        public string Html
        {
            get => _Values.TryGetValue(OEmbed.HTML, out object s) ? s?.ToString() : null;
            set => _Values[OEmbed.HTML] = value;
        }

        public int Width
        {
            get => _Values.TryGetValue(OEmbed.WIDTH, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;
            set => _Values[OEmbed.WIDTH] = value;
        }

        public int Height
        {
            get => _Values.TryGetValue(OEmbed.HEIGHT, out object obj) ? (obj as IConvertible)?.ToInt32(null) ?? 0 : 0;
            set => _Values[OEmbed.HEIGHT] = value;
        }

        /// <inheritdoc />
        public XmlSchema GetSchema()
            => null;

        /// <inheritdoc />
        public void ReadXml(XmlReader reader)
        {
            var isEmpty = reader.IsEmptyElement;
            reader.Read();

            if (isEmpty)
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                var tn = reader.LocalName;
                var key = reader.GetAttribute("Key");
                reader.ReadStartElement();

                switch (tn)
                {
                    case nameof(Boolean):
                        _Values[key] = reader.ReadContentAsBoolean();
                        break;

                    case nameof(Int32):
                        _Values[key] = reader.ReadContentAsInt();
                        break;

                    case nameof(Int64):
                        _Values[key] = reader.ReadContentAsLong();
                        break;

                    case nameof(Single):
                        _Values[key] = reader.ReadContentAsFloat();
                        break;

                    case nameof(Double):
                        _Values[key] = reader.ReadContentAsDouble();
                        break;

                    case nameof(Decimal):
                        _Values[key] = reader.ReadContentAsDecimal();
                        break;

                    default:
                        _Values[key] = reader.ReadContentAsString();
                        break;
                }

                reader.ReadEndElement();
            }

            reader.ReadEndElement();
        }

        /// <inheritdoc />
        public void WriteXml(XmlWriter writer)
        {
            foreach (var kv in _Values)
            {
                if (kv.Value != null)
                {
                    writer.WriteStartElement(kv.Value.GetType().Name);
                    writer.WriteAttributeString("Key", kv.Key);
                    writer.WriteString(kv.Value.ToString());
                    writer.WriteEndElement();
                }
            }
        }

        public Dictionary<string, object> ToDictionary()
            => _Values.ToDictionary(kv => kv.Key, kv => kv.Value);
    }
}