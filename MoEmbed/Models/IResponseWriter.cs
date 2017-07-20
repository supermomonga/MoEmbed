using System;

namespace MoEmbed.Models
{
    public interface IResponseWriter : IDisposable
    {
        void WriteStartResponse();
        void WriteProperty(string name, bool value);
        void WriteProperty(string name, double value);
        void WriteProperty(string name, object value);
        void WriteEndResponse();
    }
}