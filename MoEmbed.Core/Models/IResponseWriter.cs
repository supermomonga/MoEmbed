using System;

namespace MoEmbed.Models
{
  public interface IResponseWriter : IDisposable
  {
    void WriteStartResponse(string name = "embed");
    void WriteStartArrayProperty(string name);
    void WriteEndArrayProperty();
    void WriteStartObjectProperty(string name);
    void WriteEndObjectProperty();
    void WriteProperty(string name, bool value);
    void WriteProperty(string name, double value);
    void WriteProperty(string name, object value);
    void WriteArrayValue(string name, bool value);
    void WriteArrayValue(string name, double value);
    void WriteArrayValue(string name, object value);
    void WriteEndResponse();
  }
}
