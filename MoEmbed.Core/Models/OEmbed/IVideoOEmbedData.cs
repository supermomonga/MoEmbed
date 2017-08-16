namespace MoEmbed.Models.OEmbed
{
  /// <summary>
  /// This type is used for representing playable videos.
  /// </summary>
  public interface IVideoOEmbedData : IOEmbedData
  {
    /// <summary>
    /// Gets the HTML required to embed a video player.
    /// The HTML should have no padding or margins.
    /// Consumers may wish to load the HTML in an off-domain iframe to avoid XSS vulnerabilities.
    /// </summary>
    string Html { get; }

    /// <summary>
    /// Gets the width in pixels required to display the HTML.
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Gets the height in pixels required to display the HTML.
    /// </summary>
    int Height { get; }
  }
}
