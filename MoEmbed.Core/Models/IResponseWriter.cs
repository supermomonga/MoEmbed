using System;
using System.Threading.Tasks;

namespace MoEmbed.Models
{
    /// <summary>
    /// Provides methods to write a response.
    /// </summary>
    public interface IResponseWriter : IDisposable
    {
        #region Response

        /// <summary>
        /// Writes a start of the response.
        /// </summary>
        /// <param name="name">The name of the response element.</param>
        void WriteStartResponse(string name = "embed");

        /// <summary>
        /// Writes an end of the response.
        /// </summary>
        Task WriteEndResponseAsync();

        #endregion Response

        #region Complex Property

        /// <summary>
        /// Writes a property name and start of an array.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        void WriteStartArrayProperty(string name);

        /// <summary>
        /// Writes a end of current array property.
        /// </summary>
        void WriteEndArrayProperty();

        /// <summary>
        /// Writes a property name and start of an object.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        void WriteStartObjectProperty(string name);

        /// <summary>
        /// Writes a end of current object property.
        /// </summary>
        void WriteEndObjectProperty();

        #endregion Complex Property

        #region Primitive Property

        /// <summary>
        /// Writes a property with boolean value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        void WriteProperty(string name, bool value);

        /// <summary>
        /// Writes a property with integer value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        void WriteProperty(string name, int value);

        /// <summary>
        /// Writes a property with float value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        void WriteProperty(string name, double value);

        /// <summary>
        /// Writes a property with string value.
        /// </summary>
        /// <param name="name">The property name to write.</param>
        /// <param name="value">The value of the property.</param>
        void WriteProperty(string name, object value);

        #endregion Primitive Property

        #region Array Element

        /// <summary>
        /// Writes a start of an object.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        void WriteStartObject(string name);

        /// <summary>
        /// Writes a end of current object.
        /// </summary>
        void WriteEndObject();

        /// <summary>
        /// Writes a array element with the boolean value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        void WriteArrayValue(string name, bool value);

        /// <summary>
        /// Writes a array element with the float value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        void WriteArrayValue(string name, double value);

        /// <summary>
        /// Writes a array element with the string value.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="value">The value of the element.</param>
        void WriteArrayValue(string name, object value);

        #endregion Array Element
    }
}