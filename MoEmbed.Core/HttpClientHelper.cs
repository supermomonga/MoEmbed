using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoEmbed
{
    internal static class HttpClientHelper
    {
        public struct RedirectionResult
        {
            public RedirectionResult(HttpResponseMessage m, string u)
            {
                Message = m;
                MovedTo = u;
            }

            public HttpResponseMessage Message { get; }

            public string MovedTo { get; }
        }

        public static async Task<RedirectionResult> FollowRedirectAsync(this HttpClient httpClient, string url)
        {
            bool? moved = null;
            for (; ; )
            {
                var res = await httpClient.GetAsync(url).ConfigureAwait(false);

                switch (res.StatusCode)
                {
                    case HttpStatusCode.Moved:
                        url = res.Headers.Location.ToString();
                        moved = moved != false;
                        continue;

                    case HttpStatusCode.Ambiguous:
                    case HttpStatusCode.Found:
                    case HttpStatusCode.RedirectMethod:
                        url = res.Headers.Location.ToString();
                        moved = false;
                        continue;
                }

                return new RedirectionResult(res, moved == true ? url : null);
            }
        }
    }
}