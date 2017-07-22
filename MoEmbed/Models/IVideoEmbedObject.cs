namespace MoEmbed.Models
{
    interface IVideoEmbedObject
    {
        // Responses of this type must obey
        // the maxwidth and maxheight request parameters.

        // The HTML required to embed a video player.
        // The HTML should have no padding or margins.
        // Consumers may wish to load the HTML in
        // an off-domain iframe to avoid XSS vulnerabilities.
        string Html { get; set; }

        int Width { get; set; }
        int Height { get; set; }
    }
}

