using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                var res = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

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

        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            using (var s = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(s))
            using (var jr = new JsonTextReader(sr))
            {
                return new JsonSerializer().Deserialize<T>(jr);
            }
        }
    }
}