using MoEmbed.Models;

namespace MoEmbed
{
    /// <summary>
    ///   Has the result data, status and error message.
    /// </summary>
    public class EmbedDataResult
    {
        /// <summary>
        ///   Returns true if successfully fetched embed data.
        /// </summary>
        public bool Succeeded { get; internal set; }

        /// <summary>
        ///   Describes the error when failed to fetch embed data.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        ///   Gets the result data.
        /// </summary>
        public EmbedData Data { get; internal set; }
    }
}
