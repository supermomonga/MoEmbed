using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoEmbed.Models
{
    /// <summary>
    /// Provides methods to write a response in JSON format.
    /// </summary>
    public sealed class JsonResponseWriter : IResponseWriter
    {
        private readonly bool _LeaveOpen;
        private JsonWriter BaseWriter;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonResponseWriter" /> with specified <see
        /// cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base steam.</param>
        public JsonResponseWriter(Stream stream, bool leaveOpen = false)
        {
            BaseWriter = new JsonTextWriter(new StreamWriter(stream, new UTF8Encoding(false), 4096, leaveOpen));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonResponseWriter" /> with specified <see
        /// cref="TextWriter" />.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base writer.</param>
        public JsonResponseWriter(TextWriter textWriter, bool leaveOpen = false)
        {
            BaseWriter = new JsonTextWriter(textWriter)
            {
                CloseOutput = !leaveOpen
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonResponseWriter" /> with specified <see
        /// cref="JsonWriter" />.
        /// </summary>
        /// <param name="baseWriter">The <see cref="JsonWriter" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base writer.</param>
        public JsonResponseWriter(JsonWriter baseWriter, bool leaveOpen = false)
        {
            BaseWriter = baseWriter;
            _LeaveOpen = leaveOpen;
        }

        #endregion

        #region Response

        /// <summary>
        /// Writes a start of the response.
        /// </summary>
        /// <param name="name">
        /// The name of the response element. This argument is ignored in this implementation.
        /// </param>
        public void WriteStartResponse(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartObject();
        }

        /// <summary>
        /// Writes an end of the response.
        /// </summary>
        public async Task WriteEndResponseAsync()
        {
            ThrowIfDisposed();
            await BaseWriter.WriteEndObjectAsync();
            await BaseWriter.FlushAsync();
        }

        #endregion Response

        #region Complex Property

        /// <summary>
        /// Writes a property name and start of an array.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        public void WriteStartArrayProperty(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteStartArray();
        }

        /// <summary>
        /// Writes a end of current array property.
        /// </summary>
        public void WriteEndArrayProperty()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndArray();
        }

        /// <summary>
        /// Writes a property name and start of an object.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        public void WriteStartObjectProperty(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteStartObject();
        }

        /// <summary>
        /// Writes a end of current object property.
        /// </summary>
        public void WriteEndObjectProperty()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndObject();
        }

        #endregion Complex Property

        #region Primitive Property

        /// <summary>
        /// Writes a property with boolean value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, bool value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        /// <summary>
        /// Writes a property with integer value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, int value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        /// <summary>
        /// Writes a property with float value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, double value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        /// <summary>
        /// Writes a property with string value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WritePropertyName(name);
            BaseWriter.WriteValue(value);
        }

        #endregion Primitive Property

        #region Array Element

        /// <summary>
        /// Writes a start of an object.
        /// </summary>
        /// <param name="name">The name of the object. This argument is ignored in this implementation.</param>
        public void WriteStartObject(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartObject();
        }

        /// <summary>
        /// Writes a end of current object.
        /// </summary>
        public void WriteEndObject()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndObject();
        }

        /// <summary>
        /// Writes a array element with the boolean value.
        /// </summary>
        /// <param name="name">The name of the element. This argument is ignored in this implementation.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, bool value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteValue(value);
        }

        /// <summary>
        /// Writes a array element with the float value.
        /// </summary>
        /// <param name="name">The name of the element. This argument is ignored in this implementation.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, double value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteValue(value);
        }

        /// <summary>
        /// Writes a array element with the string value.
        /// </summary>
        /// <param name="name">The name of the element. This argument is ignored in this implementation.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteValue(value);
        }

        #endregion Array Element

        /// <summary>
        /// Provides a mechanism for releasing unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!_LeaveOpen)
            {
                BaseWriter?.Close();
            }
            BaseWriter = null;
        }

        private void ThrowIfDisposed()
        {
            if (BaseWriter == null)
            {
                throw new ObjectDisposedException(nameof(BaseWriter));
            }
        }
    }
}