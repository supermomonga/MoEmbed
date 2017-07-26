namespace MoEmbed.Models
{
    public interface IRichEmbedObject
    {
        // Responses of this type must obey
        // the maxwidth and maxheight request parameters.

        // The HTML required to display the resource.
        // The HTML should have no padding or margins.
        // Consumers may wish to load the HTML in
        // an off-domain iframe to avoid XSS vulnerabilities.
        // The markup should be valid XHTML 1.0 Basic.
        string Html { get; set; }

        int Width { get; set; }
        int Height { get; set; }
    }
}