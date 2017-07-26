using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace MoEmbed.Models
{
    public class JsonResponseWriter : IResponseWriter
    {
        private readonly bool _LeaveOpen;

        public JsonResponseWriter(Stream stream, bool leaveOpen = false)
        {
            BaseWriter = new JsonTextWriter(new StreamWriter(stream, new UTF8Encoding(false), 4096, leaveOpen));
        }

        public JsonResponseWriter(TextWriter textWriter, bool leaveOpen = false)
        {
            BaseWriter = new JsonTextWriter(textWriter)
            {
                CloseOutput = !leaveOpen
            };
        }

        public JsonResponseWriter(JsonWriter baseWriter, bool leaveOpen = false)
        {
            BaseWriter = baseWriter;
            _LeaveOpen = leaveOpen;
        }

        protected JsonWriter BaseWriter { get; private set; }

        public void WriteStartResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartObject();
        }

        public void WriteProperty(string name, bool value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        public void WriteProperty(string name, double value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        public void WriteProperty(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        public void WriteEndResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndObject();
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
                BaseWriter?.Close();
            }
            BaseWriter = null;
        }
    }
}
