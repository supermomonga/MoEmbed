using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;
using MoEmbed.Providers;

namespace MoEmbed.Models
{
    internal static class RequestContextExtensions
    {
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