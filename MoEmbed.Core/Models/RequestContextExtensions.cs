using System;
using System.Threading.Tasks;

namespace MoEmbed.Models
{
    /// <summary>
    /// Provides extensions of the <see cref="RequestContext"/>.
    /// </summary>
    public static class RequestContextExtensions
    {
        /// <summary>
        /// Asynchronously executes the specified task with retries.
        /// </summary>
        /// <param name="context">The context of the request.</param>
        /// <param name="func">A method that returns asynchronous task.</param>
        /// <returns>A task that represents the asynchronous fetch operation.</returns>
        public static async Task<EmbedData> ExecuteAsync(this RequestContext context, Func<RequestContext, Task<EmbedData>> func)
        {
            var ms = context.Service;
            for (var i = 0; ; i++)
            {
                try
                {
                    return await func(context).ConfigureAwait(false);
                }
                catch
                {
                    // TODO: log exception
                    if (i < ms.RequestRetryCount)
                    {
                        try
                        {
                            await Task.Delay((int)(ms.RequestRetryWait.TotalMilliseconds * Math.Pow(ms.RequestRetryFactor, i))).ConfigureAwait(false);

                            continue;
                        }
                        catch { }
                    }

                    throw;
                }
            }
        }
    }
}