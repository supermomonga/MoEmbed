using System;
using System.IO;
using System.Text;
using System.Xml;

namespace MoEmbed.Models
{
    public class XmlResponseWriter : IResponseWriter
    {
        private readonly bool _LeaveOpen;

        public XmlResponseWriter(Stream stream, bool leaveOpen = false)
        {
            BaseWriter = XmlWriter.Create(new StreamWriter(stream, new UTF8Encoding(false), 4096, leaveOpen));
        }

        public XmlResponseWriter(TextWriter textWriter, bool leaveOpen = false)
        {
            BaseWriter = XmlWriter.Create(textWriter, new XmlWriterSettings()
            {
                CloseOutput = !leaveOpen
            });
        }

        public XmlResponseWriter(XmlWriter baseWriter, bool leaveOpen = false)
        {
            BaseWriter = baseWriter;
            _LeaveOpen = leaveOpen;
        }
        protected XmlWriter BaseWriter { get; private set; }

        public void WriteStartResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement("oembed");
        }

        public void WriteProperty(string name, bool value)
            => WriteProperty(name, value ? "true" : "false");

        public void WriteProperty(string name, double value)
            => WriteProperty(name, value.ToString("r"));

        public void WriteProperty(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
            BaseWriter.WriteString(value?.ToString() ?? string.Empty);
            BaseWriter.WriteEndElement();
        }

        public void WriteEndResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();
            BaseWriter.Flush();
        }

        private void ThrowIfDisposed()
        {
            if (BaseWriter == null)
            {
                throw new ObjectDisposedException(nameof(BaseWriter));
            }
        }

        public void Dispose()
        {
            if (!_LeaveOpen)
            {
                BaseWriter?.Dispose();
            }
            BaseWriter = null;
        }
    }
}
