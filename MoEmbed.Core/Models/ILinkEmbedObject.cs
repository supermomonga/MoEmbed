namespace MoEmbed.Models
{
    public interface ILinkEmbedObject
    {
        // Responses of this type must obey
        // the maxwidth and maxheight request parameters.

        string Html { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}