using System;
using System.Xml;

namespace MoEmbed.Models
{
    public class XmlResponseWriter : IResponseWriter
    {
        private readonly bool _LeaveOpen;

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
            => WriteProperty(name, value ? "true": "false");

        public void WriteProperty(string name, double value)
            => WriteProperty(name, value.ToString("r"));
        
        public void WriteProperty(string name, object value)
        {
            ThrowIfDisposed();
            if(value != null)
            {
                BaseWriter.WriteStartElement(name);
                BaseWriter.WriteString(value.ToString());
                BaseWriter.WriteEndElement(); 
            }
        }

        public void WriteEndResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();            
        }

        private void ThrowIfDisposed()
        {
            if(BaseWriter == null)
            {
                throw new ObjectDisposedException(nameof(BaseWriter));
            }
        }

        public void Dispose()
        {
            if(!_LeaveOpen)
            {
                BaseWriter?.Dispose();
            }
            BaseWriter = null;
        }
    }
}