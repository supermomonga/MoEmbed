using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoEmbed
{
    internal static class HttpClientHelper
    {
        public struct RedirectionResult
        {
            public RedirectionResult(HttpResponseMessage m, Uri u)
            {
                Message = m;
                MovedToUrl = u;
            }

            public HttpResponseMessage Message { get; }

            public Uri MovedToUrl { get; }
        }

        public static async Task<RedirectionResult> FollowRedirectAsync(this HttpClient httpClient, Uri url)
        {
            bool? moved = null;
            for (; ; )
            {
                var res = await httpClient.GetAsync(url).ConfigureAwait(false);

                switch (res.StatusCode)
                {
                    case HttpStatusCode.Moved:
                        url = res.Headers.Location;
                        moved = moved != false;
                        continue;

                    case HttpStatusCode.Ambiguous:
                    case HttpStatusCode.Found:
                    case HttpStatusCode.RedirectMethod:
                        url = res.Headers.Location;
                        moved = false;
                        continue;
                }

                return new RedirectionResult(res, moved == true ? url : null);
            }
        }
    }
}