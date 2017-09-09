using System;
using System.IO;
using System.Text;
using System.Xml;

namespace MoEmbed.Models
{
    /// <summary>
    /// Provides methods to write a response in XML format.
    /// </summary>
    public sealed class XmlResponseWriter : IResponseWriter
    {
        private readonly bool _LeaveOpen;

        private XmlWriter BaseWriter;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResponseWriter" /> with specified <see
        /// cref="Stream" />.
        /// </summary>
        /// <param name="stream">The <see cref="Stream" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base steam.</param>
        public XmlResponseWriter(Stream stream, bool leaveOpen = false)
        {
            BaseWriter = XmlWriter.Create(new StreamWriter(stream, new UTF8Encoding(false), 4096, leaveOpen));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResponseWriter" /> with specified <see
        /// cref="TextWriter" />.
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base writer.</param>
        public XmlResponseWriter(TextWriter textWriter, bool leaveOpen = false)
        {
            BaseWriter = XmlWriter.Create(textWriter, new XmlWriterSettings()
            {
                CloseOutput = !leaveOpen
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResponseWriter" /> with specified <see
        /// cref="XmlWriter" />.
        /// </summary>
        /// <param name="baseWriter">The <see cref="XmlWriter" /> to write response.</param>
        /// <param name="leaveOpen">A value indicating whether the writer disposes base writer.</param>
        public XmlResponseWriter(XmlWriter baseWriter, bool leaveOpen = false)
        {
            BaseWriter = baseWriter;
            _LeaveOpen = leaveOpen;
        }

        #endregion Constructors

        #region Response

        /// <summary>
        /// Writes a start of the response.
        /// </summary>
        /// <param name="name">The name of the response element.</param>
        public void WriteStartResponse(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
        }

        /// <summary>
        /// Writes an end of the response.
        /// </summary>
        public void WriteEndResponse()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();
            BaseWriter.Flush();
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
            BaseWriter.WriteStartElement(name);
        }

        /// <summary>
        /// Writes a end of current array property.
        /// </summary>
        public void WriteEndArrayProperty()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();
        }

        /// <summary>
        /// Writes a property name and start of an object.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        public void WriteStartObjectProperty(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
        }

        /// <summary>
        /// Writes a end of current object property.
        /// </summary>
        public void WriteEndObjectProperty()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();
        }

        #endregion Complex Property

        #region Primitive Property

        /// <summary>
        /// Writes a property with boolean value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, bool value)
            => WriteProperty(name, value ? "true" : "false");

        /// <summary>
        /// Writes a property with integer value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, int value)
            => WriteProperty(name, value.ToString());

        /// <summary>
        /// Writes a property with float value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        public void WriteProperty(string name, double value)
            => WriteProperty(name, value.ToString("r"));

        /// <summary>
        /// Writes a property with string value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>

        public void WriteProperty(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
            BaseWriter.WriteString(value?.ToString() ?? string.Empty);
            BaseWriter.WriteEndElement();
        }

        #endregion Primitive Property

        #region Array Element

        /// <summary>
        /// Writes a start of an object.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        public void WriteStartObject(string name)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
        }

        /// <summary>
        /// Writes a end of current object.
        /// </summary>
        public void WriteEndObject()
        {
            ThrowIfDisposed();
            BaseWriter.WriteEndElement();
        }

        /// <summary>
        /// Writes a array element with the boolean value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, bool value)
            => WriteArrayValue(name, value ? "true" : "false");

        /// <summary>
        /// Writes a array element with the float value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, double value)
            => WriteArrayValue(name, value.ToString("r"));

        /// <summary>
        /// Writes a array element with the string value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        public void WriteArrayValue(string name, object value)
        {
            ThrowIfDisposed();
            BaseWriter.WriteStartElement(name);
            BaseWriter.WriteString(value?.ToString() ?? string.Empty);
            BaseWriter.WriteEndElement();
        }

        #endregion Array Element

        /// <summary>
        /// Provides a mechanism for releasing unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!_LeaveOpen)
            {
                BaseWriter?.Dispose();
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