using System.Collections.Generic;
using System.Xml;

namespace MoEmbed
{
    internal static class XmlElementHelper
    {
        public static IEnumerable<XmlElement> Elements(this XmlElement parent, string localName)
        {
            foreach (XmlNode c in parent.ChildNodes)
            {
                if (c.NodeType == XmlNodeType.Element && c.LocalName == localName)
                {
                    yield return (XmlElement)c;
                }
            }
        }

        public static XmlElement Element(this XmlElement parent, string localName)
        {
            foreach (XmlNode c in parent.ChildNodes)
            {
                if (c.NodeType == XmlNodeType.Element && c.LocalName == localName)
                {
                    return (XmlElement)c;
                }
            }
            return null;
        }
    }
}