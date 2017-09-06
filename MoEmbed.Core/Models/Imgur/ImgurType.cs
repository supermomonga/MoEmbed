using System;
using System.Collections.Generic;
using System.Text;

namespace MoEmbed.Models.Imgur
{
    /// <summary>
    /// Represents a type of imgur.com URL.
    /// </summary>
    public enum ImgurType : Byte
    {
        /// <summary>
        /// Type is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Image page.
        /// </summary>
        Image,

        /// <summary>
        /// Album page.
        /// </summary>
        Album,

        /// <summary>
        /// Gallery page.
        /// </summary>
        Gallery
    }
}
