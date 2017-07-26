namespace MoEmbed.Models
{
    public interface IPhotoEmbedObject
    {
        // Responses of this type must obey
        // the maxwidth and maxheight request parameters.

        // The source URL of the image.
        // Consumers should be able to insert this URL into an
        // <img> element. Only HTTP and HTTPS URLs are valid.
        string Url { get; set; }

        int Width { get; set; }
        int Height { get; set; }
    }
}