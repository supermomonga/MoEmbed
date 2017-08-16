namespace MoEmbed.Models.OEmbed
{
  /// <summary>
  /// This type is used for rich HTML content that does not fall under one of the other categories.
  /// </summary>
  public interface IRichOEmbedData : IOEmbedData
  {
    /// <summary>
    /// Gets the HTML required to display the resource.
    /// The HTML should have no padding or margins.
    /// Consumers may wish to load the HTML in an off-domain iframe to avoid XSS vulnerabilities.
    /// The markup should be valid XHTML 1.0 Basic.
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
