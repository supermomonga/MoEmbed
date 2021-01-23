using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MoEmbed.Models;
namespace MoEmbed.Providers
{
    /// <summary>
    /// Handles oEmbed request for <see href="http://www.23hq.com" />.
    /// </summary>
    public sealed partial class TwentyThreeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.23hq\.com/.*/photo/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.23hq.com";
            yield return "23hq.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.23hq.com/23/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://alpha.app.net/browse/posts/" />.
    /// </summary>
    public sealed partial class AlphaAppNetMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://alpha\.app\.net/.*/post/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "alpha.app.net";
            yield return "app.net";
            yield return "photos.app.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://alpha-api.app.net/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://live.amcharts.com/" />.
    /// </summary>
    public sealed partial class AmchartsLiveEditorMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://live\.amcharts\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "live.amcharts.com";
            yield return "amcharts.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://live.amcharts.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.animatron.com/" />.
    /// </summary>
    public sealed partial class AnimatronMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.animatron\.com/project/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.animatron.com";
            yield return "animatron.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://animatron.com/oembed/json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://animoto.com/" />.
    /// </summary>
    public sealed partial class AnimotoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://animoto\.com/play/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "animoto.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://animoto.com/oembeds/create", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://audiosnaps.com" />.
    /// </summary>
    public sealed partial class AudiosnapsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://audiosnaps\.com/k/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "audiosnaps.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://audiosnaps.com/service/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://blackfire.io" />.
    /// </summary>
    public sealed partial class BlackfireIoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://blackfire\.io/profiles/.*/graph");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "blackfire.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://blackfire.io/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://boxofficebuz.com" />.
    /// </summary>
    public sealed partial class BoxofficebuzMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://boxofficebuz\.com");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "boxofficebuz.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://boxofficebuz.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://cacoo.com" />.
    /// </summary>
    public sealed partial class CacooMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://cacoo\.com/diagrams/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "cacoo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://cacoo.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://img.catbo.at/" />.
    /// </summary>
    public sealed partial class CatboatMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://img\.catbo\.at/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "img.catbo.at";
            yield return "catbo.at";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("http://img.catbo.at/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.chartblocks.com/" />.
    /// </summary>
    public sealed partial class ChartblocksMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://public\.chartblocks\.com/c/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "public.chartblocks.com";
            yield return "chartblocks.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://embed.chartblocks.com/1.0/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.chirbit.com/" />.
    /// </summary>
    public sealed partial class ChirbitComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://chirb\.it/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "chirb.it";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://chirb.it/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.circuitlab.com/" />.
    /// </summary>
    public sealed partial class CircuitlabMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.circuitlab\.com/circuit/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.circuitlab.com";
            yield return "circuitlab.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.circuitlab.com/circuit/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.clipland.com/" />.
    /// </summary>
    public sealed partial class CliplandMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.clipland\.com/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.clipland.com";
            yield return "clipland.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.clipland.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://clyp.it/" />.
    /// </summary>
    public sealed partial class ClypMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://clyp\.it/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "clyp.it";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.clyp.it/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://codepen.io" />.
    /// </summary>
    public sealed partial class CodepenMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://codepen\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "codepen.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://codepen.io/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://codepoints.net" />.
    /// </summary>
    public sealed partial class CodepointsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://codepoints\.net/|https://codepoints\.net/|http://www\.codepoints\.net/|https://www\.codepoints\.net/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "codepoints.net";
            yield return "www.codepoints.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://codepoints.net/api/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.collegehumor.com/" />.
    /// </summary>
    public sealed partial class CollegehumorMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.collegehumor\.com/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.collegehumor.com";
            yield return "collegehumor.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.collegehumor.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://coub.com/" />.
    /// </summary>
    public sealed partial class CoubMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://coub\.com/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "coub.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://coub.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://crowdranking.com" />.
    /// </summary>
    public sealed partial class CrowdRankingMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://crowdranking\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "crowdranking.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://crowdranking.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.dailymotion.com" />.
    /// </summary>
    public sealed partial class DailymotionMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.dailymotion\.com/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.dailymotion.com";
            yield return "dailymotion.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.dailymotion.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.dailymile.com" />.
    /// </summary>
    public sealed partial class DailyMileMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.dailymile\.com/people/.*/entries/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.dailymile.com";
            yield return "dailymile.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.dailymile.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.deviantart.com" />.
    /// </summary>
    public sealed partial class DeviantartComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.deviantart\.com/art/|http://.*\.deviantart\.com/.*\#/d|http://fav\.me/|http://sta\.sh/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "deviantart.com";
            yield return "fav.me";
            yield return "sta.sh";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://backend.deviantart.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.didacte.com/" />.
    /// </summary>
    public sealed partial class DidacteMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.didacte\.com/a/course/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "didacte.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://*.didacte.com/cards/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.dipity.com" />.
    /// </summary>
    public sealed partial class DipityMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.dipity\.com/.*/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.dipity.com";
            yield return "dipity.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.dipity.com/oembed/timeline/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.docdroid.net/" />.
    /// </summary>
    public sealed partial class DocdroidMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://.*\.docdroid\.net/|http://.*\.docdroid\.net/|https://docdro\.id/|http://docdro\.id/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "docdroid.net";
            yield return "docdro.id";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.docdroid.net/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.docs.com" />.
    /// </summary>
    public sealed partial class DocsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://docs\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "docs.com";
            yield return "www.docs.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://docs.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://dotsub.com/" />.
    /// </summary>
    public sealed partial class DotsubMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://dotsub\.com/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "dotsub.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://dotsub.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.edocr.com" />.
    /// </summary>
    public sealed partial class EdocrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://edocr\.com/docs/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "edocr.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://edocr.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.edumedia-sciences.com/" />.
    /// </summary>
    public sealed partial class EdumediaSciencesComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.edumedia-sciences\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.edumedia-sciences.com";
            yield return "edumedia-sciences.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://www.edumedia-sciences.com/oembed.xml", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://egliseinfo.catholique.fr/" />.
    /// </summary>
    public sealed partial class EgliseinfoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://egliseinfo\.catholique\.fr/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "egliseinfo.catholique.fr";
            yield return "catholique.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://egliseinfo.catholique.fr/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://api.embed.ly/" />.
    /// </summary>
    public sealed partial class EmbedlyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://api\.embed\.ly/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "api.embed.ly";
            yield return "embed.ly";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.embed.ly/1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://embedarticles.com/" />.
    /// </summary>
    public sealed partial class EmbedArticlesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://embedarticles\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "embedarticles.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://embedarticles.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://eyrie.io/" />.
    /// </summary>
    public sealed partial class EyrieioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://eyrie\.io/board/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "eyrie.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://eyrie.io/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.facebook.com/" />.
    /// </summary>
    public sealed partial class FacebookMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.facebook\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.facebook.com";
            yield return "facebook.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://www.facebook.com/plugins/video/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://flat.io" />.
    /// </summary>
    public sealed partial class FlatMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://flat\.io/score/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "flat.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://flat.io/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.flickr.com/" />.
    /// </summary>
    public sealed partial class FlickrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.flickr\.com/photos/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "flickr.com";
            yield return "flic.kr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.flickr.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.foxsports.com.au" />.
    /// </summary>
    public sealed partial class FoxSportsAustraliaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://fiso\.foxsports\.com\.au/isomorphic-widget/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "fiso.foxsports.com.au";
            yield return "foxsports.com.au";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://fiso.foxsports.com.au/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://framebuzz.com/" />.
    /// </summary>
    public sealed partial class FramebuzzMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://framebuzz\.com/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "framebuzz.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://framebuzz.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.funnyordie.com/" />.
    /// </summary>
    public sealed partial class FunnyordieMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.funnyordie\.com/videos/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.funnyordie.com";
            yield return "funnyordie.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.funnyordie.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://geo-en.hlipp.de/" />.
    /// </summary>
    public sealed partial class GeographMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.geograph\.org\.uk/|http://.*\.geograph\.co\.uk/|http://.*\.geograph\.ie/|http://.*\.wikimedia\.org/.*_geograph\.org\.uk_|http://.*\.geograph\.org\.gg/|http://.*\.geograph\.org\.je/|http://channel-islands\.geograph\.org/|http://channel-islands\.geographs\.org/|http://.*\.channel\.geographs\.org/|http://geo-en\.hlipp\.de/|http://geo\.hlipp\.de/|http://germany\.geograph\.org/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "geograph.org.uk";
            yield return "geograph.co.uk";
            yield return "geograph.ie";
            yield return "wikimedia.org";
            yield return "geograph.org.gg";
            yield return "geograph.org.je";
            yield return "channel-islands.geograph.org";
            yield return "geograph.org";
            yield return "channel-islands.geographs.org";
            yield return "geographs.org";
            yield return "channel.geographs.org";
            yield return "geo-en.hlipp.de";
            yield return "hlipp.de";
            yield return "geo.hlipp.de";
            yield return "germany.geograph.org";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://geo.hlipp.de/restapi.php/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.gettyimages.com/" />.
    /// </summary>
    public sealed partial class GettyImagesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://gty\.im/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "gty.im";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://embed.gettyimages.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://gfycat.com/" />.
    /// </summary>
    public sealed partial class GfycatMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://gfycat\.com/|http://www\.gfycat\.com/|https://gfycat\.com/|https://www\.gfycat\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "gfycat.com";
            yield return "www.gfycat.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.gfycat.com/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://giphy.com" />.
    /// </summary>
    public sealed partial class GIPHYMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://giphy\.com/gifs/|http://gph\.is/|https://media\.giphy\.com/media/.*/giphy\.gif)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "giphy.com";
            yield return "gph.is";
            yield return "media.giphy.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://giphy.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://huffduffer.com" />.
    /// </summary>
    public sealed partial class HuffdufferMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://huffduffer\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "huffduffer.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://huffduffer.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.hulu.com/" />.
    /// </summary>
    public sealed partial class HuluMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.hulu\.com/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.hulu.com";
            yield return "hulu.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.hulu.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.iFixit.com" />.
    /// </summary>
    public sealed partial class IfixitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.ifixit\.com/Guide/View/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.ifixit.com";
            yield return "ifixit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.ifixit.com/Embed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.ifttt.com/" />.
    /// </summary>
    public sealed partial class IftttMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://ifttt\.com/recipes/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ifttt.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.ifttt.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://player.indacolive.com/" />.
    /// </summary>
    public sealed partial class IndacoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://player\.indacolive\.com/player/jwp/clients/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "player.indacolive.com";
            yield return "indacolive.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://player.indacolive.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://infogr.am/" />.
    /// </summary>
    public sealed partial class InfogramMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://infogr\.am/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "infogr.am";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://infogr.am/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.inoreader.com" />.
    /// </summary>
    public sealed partial class InoreaderMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.inoreader\.com/oembed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.inoreader.com";
            yield return "inoreader.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.inoreader.com/oembed/api/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://inphood.com/" />.
    /// </summary>
    public sealed partial class InphoodMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.inphood\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "inphood.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.inphood.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://instagram.com" />.
    /// </summary>
    public sealed partial class InstagramMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://instagram\.com/p/|http://instagr\.am/p/|http://www\.instagram\.com/p/|http://www\.instagr\.am/p/|https://instagram\.com/p/|https://instagr\.am/p/|https://www\.instagram\.com/p/|https://www\.instagr\.am/p/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "instagram.com";
            yield return "instagr.am";
            yield return "www.instagram.com";
            yield return "www.instagr.am";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.instagram.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.isnare.com/" />.
    /// </summary>
    public sealed partial class IsnareArticlesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.isnare\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.isnare.com";
            yield return "isnare.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.isnare.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.kickstarter.com" />.
    /// </summary>
    public sealed partial class KickstarterMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.kickstarter\.com/projects/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.kickstarter.com";
            yield return "kickstarter.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.kickstarter.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.kidoju.com/" />.
    /// </summary>
    public sealed partial class KidojuMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.kidoju\.com/en/x/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.kidoju.com";
            yield return "kidoju.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.kidoju.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://kit.com/" />.
    /// </summary>
    public sealed partial class KitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://kit\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "kit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.kit.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.kitchenbowl.com" />.
    /// </summary>
    public sealed partial class KitchenbowlMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.kitchenbowl\.com/recipe/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.kitchenbowl.com";
            yield return "kitchenbowl.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.kitchenbowl.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://jdr.knacki.info" />.
    /// </summary>
    public sealed partial class KnackiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://jdr\.knacki\.info/meuh/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "jdr.knacki.info";
            yield return "knacki.info";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://jdr.knacki.info/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://learningapps.org/" />.
    /// </summary>
    public sealed partial class LearningappsOrgMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://learningapps\.org/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "learningapps.org";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://learningapps.org/oembed.php", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://mathembed.com" />.
    /// </summary>
    public sealed partial class MathembedMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://mathembed\.com/latex\?inputText=");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mathembed.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://mathembed.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.meetup.com" />.
    /// </summary>
    public sealed partial class MeetupMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://meetup\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "meetup.com";
            yield return "meetu.ps";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.meetup.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://me.me/" />.
    /// </summary>
    public sealed partial class MemeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://me\.me/i/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "me.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://me.me/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://mixcloud.com/" />.
    /// </summary>
    public sealed partial class MixcloudMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.mixcloud\.com/.*/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.mixcloud.com";
            yield return "mixcloud.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.mixcloud.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.mobypicture.com" />.
    /// </summary>
    public sealed partial class MobyPictureMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.mobypicture\.com/user/.*/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.mobypicture.com";
            yield return "mobypicture.com";
            yield return "moby.to";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.mobypicture.com/oEmbed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://modelo.io/" />.
    /// </summary>
    public sealed partial class ModeloMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://beta\.modelo\.io/embedded/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "beta.modelo.io";
            yield return "modelo.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://portal.modelo.io/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mybeweeg.com" />.
    /// </summary>
    public sealed partial class MybeweegMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://mybeweeg\.com/w/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mybeweeg.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mybeweeg.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.nanoo.tv/" />.
    /// </summary>
    public sealed partial class NanooMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.nanoo\.tv/link/|http://nanoo\.tv/link/|http://.*\.nanoo\.pro/link/|http://nanoo\.pro/link/|https://.*\.nanoo\.tv/link/|https://nanoo\.tv/link/|https://.*\.nanoo\.pro/link/|https://nanoo\.pro/link/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "nanoo.tv";
            yield return "nanoo.pro";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.nanoo.tv/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.nfb.ca/" />.
    /// </summary>
    public sealed partial class NfbCaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.nfb\.ca/film/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "nfb.ca";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.nfb.ca/remote/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.odds.com.au" />.
    /// </summary>
    public sealed partial class OddsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.odds\.com\.au/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.odds.com.au";
            yield return "odds.com.au";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.odds.com.au/api/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://mix.office.com/" />.
    /// </summary>
    public sealed partial class OfficeMixMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://mix\.office\.com/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mix.office.com";
            yield return "office.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mix.office.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://official.fm" />.
    /// </summary>
    public sealed partial class OfficialFmMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://official\.fm/tracks/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "official.fm";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://official.fm/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://on.aol.com/" />.
    /// </summary>
    public sealed partial class OnAolMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://on\.aol\.com/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "on.aol.com";
            yield return "aol.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://on.aol.com/api", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.ora.tv/" />.
    /// </summary>
    public sealed partial class OraTvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.ora\.tv/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.ora.tv";
            yield return "ora.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.ora.tv/oembed/*", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://orbitvu.co" />.
    /// </summary>
    public sealed partial class OrbitvuMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://orbitvu\.co/001/.*/ov3601/view|https://orbitvu\.co/001/.*/ov3601/.*/view|https://orbitvu\.co/001/.*/ov3602/.*/view|https://orbitvu\.co/001/.*/2/orbittour/.*/view|https://orbitvu\.co/001/.*/1/2/orbittour/.*/view|http://orbitvu\.co/001/.*/ov3601/view|http://orbitvu\.co/001/.*/ov3601/.*/view|http://orbitvu\.co/001/.*/ov3602/.*/view|http://orbitvu\.co/001/.*/2/orbittour/.*/view|http://orbitvu\.co/001/.*/1/2/orbittour/.*/view)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "orbitvu.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://orbitvu.co/service/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.oumy.com/" />.
    /// </summary>
    public sealed partial class OumyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.oumy\.com/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.oumy.com";
            yield return "oumy.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.oumy.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.pastery.net" />.
    /// </summary>
    public sealed partial class PasteryMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://pastery\.net/|https://pastery\.net/|http://www\.pastery\.net/|https://www\.pastery\.net/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "pastery.net";
            yield return "www.pastery.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.pastery.net/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.pixdor.com/" />.
    /// </summary>
    public sealed partial class PixdorMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://store\.pixdor\.com/place-marker-widget/.*/show");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "store.pixdor.com";
            yield return "pixdor.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://store.pixdor.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://polldaddy.com" />.
    /// </summary>
    public sealed partial class PollDaddyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.polldaddy\.com/s/|http://.*\.polldaddy\.com/poll/|http://.*\.polldaddy\.com/ratings/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "polldaddy.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://polldaddy.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.sellwithport.com/" />.
    /// </summary>
    public sealed partial class PortMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.sellwithport\.com/\#/buyer/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.sellwithport.com";
            yield return "sellwithport.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.sellwithport.com/v1.0/buyer/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://portfolium.com" />.
    /// </summary>
    public sealed partial class PortfoliumMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://portfolium\.com/entry/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "portfolium.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.portfolium.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.punters.com.au" />.
    /// </summary>
    public sealed partial class PuntersMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.punters\.com\.au/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.punters.com.au";
            yield return "punters.com.au";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.punters.com.au/api/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.quizz.biz/" />.
    /// </summary>
    public sealed partial class QuizBizMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.quiz\.biz/quizz-.*\.html");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.quiz.biz";
            yield return "quiz.biz";
            yield return "www.quizz.biz";
            yield return "quizz.biz";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.quizz.biz/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://rapidengage.com" />.
    /// </summary>
    public sealed partial class RapidengageMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://rapidengage\.com/s/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "rapidengage.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://rapidengage.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://reddit.com/" />.
    /// </summary>
    public sealed partial class RedditMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://reddit\.com/r/.*/comments/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "reddit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.reddit.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.releasewire.com/" />.
    /// </summary>
    public sealed partial class ReleasewireMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://rwire\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "rwire.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://publisher.releasewire.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://repubhub.icopyright.net/" />.
    /// </summary>
    public sealed partial class RepubhubMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://repubhub\.icopyright\.net/freePost\.act\?");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "repubhub.icopyright.net";
            yield return "icopyright.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://repubhub.icopyright.net/oembed.act", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.reverbnation.com/" />.
    /// </summary>
    public sealed partial class ReverbnationMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.reverbnation\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.reverbnation.com";
            yield return "reverbnation.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.reverbnation.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://roomshare.jp" />.
    /// </summary>
    public sealed partial class RoomshareMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://roomshare\.jp/post/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "roomshare.jp";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://roomshare.jp/en/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://rumble.com/" />.
    /// </summary>
    public sealed partial class RumbleMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://rumble\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "rumble.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://rumble.com/api/Media/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://videos.sapo.pt" />.
    /// </summary>
    public sealed partial class SapoVideosMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://videos\.sapo\.pt/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "videos.sapo.pt";
            yield return "sapo.pt";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://videos.sapo.pt/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.screen9.com/" />.
    /// </summary>
    public sealed partial class Screen9MetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.screen9\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.screen9.com";
            yield return "screen9.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.screen9.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.screencast.com/" />.
    /// </summary>
    public sealed partial class ScreencastComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.screencast\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.screencast.com";
            yield return "screencast.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.screencast.com/external/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.screenr.com/" />.
    /// </summary>
    public sealed partial class ScreenrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.screenr\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.screenr.com";
            yield return "screenr.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.screenr.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://scribblemaps.com" />.
    /// </summary>
    public sealed partial class ScribblemapsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.scribblemaps\.com/maps/view/|https://www\.scribblemaps\.com/maps/view/|http://scribblemaps\.com/maps/view/|https://scribblemaps\.com/maps/view/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.scribblemaps.com";
            yield return "scribblemaps.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://scribblemaps.com/api/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.scribd.com/" />.
    /// </summary>
    public sealed partial class ScribdMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.scribd\.com/doc/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.scribd.com";
            yield return "scribd.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.scribd.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.shortnote.jp/" />.
    /// </summary>
    public sealed partial class ShortnoteMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.shortnote\.jp/view/notes/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.shortnote.jp";
            yield return "shortnote.jp";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.shortnote.jp/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://shoudio.com" />.
    /// </summary>
    public sealed partial class ShoudioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://shoudio\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "shoudio.com";
            yield return "shoud.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://shoudio.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://showtheway.io" />.
    /// </summary>
    public sealed partial class ShowTheWayMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://showtheway\.io/to/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "showtheway.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://showtheway.io/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.silk.co/" />.
    /// </summary>
    public sealed partial class SilkMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.silk\.co/explore/|https://.*\.silk\.co/explore/|http://.*\.silk\.co/s/embed/|https://.*\.silk\.co/s/embed/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "silk.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.silk.co/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://onsizzle.com/" />.
    /// </summary>
    public sealed partial class SizzleMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://onsizzle\.com/i/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "onsizzle.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://onsizzle.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://sketchfab.com" />.
    /// </summary>
    public sealed partial class SketchfabMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://sketchfab\.com/models/|https://sketchfab\.com/models/|https://sketchfab\.com/.*/folders/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "sketchfab.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://sketchfab.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.slideshare.net/" />.
    /// </summary>
    public sealed partial class SlideshareMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.slideshare\.net/.*/|http://fr\.slideshare\.net/.*/|http://de\.slideshare\.net/.*/|http://es\.slideshare\.net/.*/|http://pt\.slideshare\.net/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.slideshare.net";
            yield return "slideshare.net";
            yield return "fr.slideshare.net";
            yield return "de.slideshare.net";
            yield return "es.slideshare.net";
            yield return "pt.slideshare.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.slideshare.net/api/oembed/2", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.smugmug.com/" />.
    /// </summary>
    public sealed partial class SmugmugMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.smugmug\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "smugmug.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://api.smugmug.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://soundcloud.com/" />.
    /// </summary>
    public sealed partial class SoundcloudMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://soundcloud\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "soundcloud.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://soundcloud.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://soundsgood.co" />.
    /// </summary>
    public sealed partial class SoundsgoodMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://play\.soundsgood\.co/playlist/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.soundsgood.co";
            yield return "soundsgood.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://play.soundsgood.co/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://speakerdeck.com" />.
    /// </summary>
    public sealed partial class SpeakerdeckMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://speakerdeck\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "speakerdeck.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://speakerdeck.com/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.spreaker.com/" />.
    /// </summary>
    public sealed partial class SpreakerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.spreaker\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "spreaker.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.spreaker.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://streamable.com/" />.
    /// </summary>
    public sealed partial class StreamableMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://streamable\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "streamable.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://api.streamable.com/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.streamone.nl" />.
    /// </summary>
    public sealed partial class StreamonecloudMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://content\.streamonecloud\.net/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "content.streamonecloud.net";
            yield return "streamonecloud.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://content.streamonecloud.net/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.sway.com" />.
    /// </summary>
    public sealed partial class SwayMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://sway\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "sway.com";
            yield return "www.sway.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://sway.com/api/v1.0/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://ted.com" />.
    /// </summary>
    public sealed partial class TedMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://ted\.com/talks/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ted.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.ted.com/talks/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://theysaidso.com/" />.
    /// </summary>
    public sealed partial class TheySaidSoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://theysaidso\.com/image/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "theysaidso.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://theysaidso.com/extensions/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.nytimes.com" />.
    /// </summary>
    public sealed partial class TheNewYorkTimesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.nytimes\.com/svc/oembed|https://nytimes\.com/|https://.*\.nytimes\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.nytimes.com";
            yield return "nytimes.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.nytimes.com/svc/oembed/json/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.tickcounter.com" />.
    /// </summary>
    public sealed partial class TickcounterMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.tickcounter\.com/countdown/|http://www\.tickcounter\.com/countup/|http://www\.tickcounter\.com/ticker/|http://www\.tickcounter\.com/worldclock/|https://www\.tickcounter\.com/countdown/|https://www\.tickcounter\.com/countup/|https://www\.tickcounter\.com/ticker/|https://www\.tickcounter\.com/worldclock/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.tickcounter.com";
            yield return "tickcounter.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.tickcounter.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.topy.se/" />.
    /// </summary>
    public sealed partial class TopyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.topy\.se/image/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.topy.se";
            yield return "topy.se";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.topy.se/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.twitch.tv" />.
    /// </summary>
    public sealed partial class TwitchMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://clips\.twitch\.tv/|https://clips\.twitch\.tv/|http://www\.twitch\.tv/|https://www\.twitch\.tv/|http://twitch\.tv/|https://twitch\.tv/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "clips.twitch.tv";
            yield return "twitch.tv";
            yield return "www.twitch.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.twitch.tv/v4/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://player.ubideo.com/" />.
    /// </summary>
    public sealed partial class UbideoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://player\.ubideo\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "player.ubideo.com";
            yield return "ubideo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://player.ubideo.com/api/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mais.uol.com.br/" />.
    /// </summary>
    public sealed partial class UolMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.uol\.com\.br/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "uol.com.br";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mais.uol.com.br/apiuol/v3/oembed/view", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.ustream.tv" />.
    /// </summary>
    public sealed partial class UstreamMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.ustream\.tv/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ustream.tv";
            yield return "ustream.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.ustream.tv/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://uttles.com" />.
    /// </summary>
    public sealed partial class UttlesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://uttles\.com/uttle/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "uttles.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://uttles.com/api/reply/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://veer.tv/" />.
    /// </summary>
    public sealed partial class VeerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://veer\.tv/videos/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "veer.tv";
            yield return "veervr.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.veervr.tv/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://verse.media/" />.
    /// </summary>
    public sealed partial class VerseMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://verse\.media/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "verse.media";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://verse.media/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.vevo.com/" />.
    /// </summary>
    public sealed partial class VevoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.vevo\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.vevo.com";
            yield return "vevo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.vevo.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.videojug.com" />.
    /// </summary>
    public sealed partial class VideojugMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.videojug\.com/film/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.videojug.com";
            yield return "videojug.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://www.videojug.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vidl.it/" />.
    /// </summary>
    public sealed partial class VidlitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vidl\.it/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vidl.it";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.vidl.it/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vimeo.com/" />.
    /// </summary>
    public sealed partial class VimeoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vimeo\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vimeo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://vimeo.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vine.co/" />.
    /// </summary>
    public sealed partial class VineMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://vine\.co/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vine.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://vine.co/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vlipsy.com/" />.
    /// </summary>
    public sealed partial class VlipsyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vlipsy\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vlipsy.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://vlipsy.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.wiredrive.com/" />.
    /// </summary>
    public sealed partial class WiredriveMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.wiredrive\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wiredrive.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://*.wiredrive.com/present-oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.wizer.me/" />.
    /// </summary>
    public sealed partial class WizerMeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.wizer\.me/learn/|https://.*\.wizer\.me/learn/|http://.*\.wizer\.me/preview/|https://.*\.wizer\.me/preview/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wizer.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://app.wizer.me/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.wootled.com/" />.
    /// </summary>
    public sealed partial class WootledMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.wootled\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.wootled.com";
            yield return "wootled.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.wootled.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://wordpress.com/" />.
    /// </summary>
    public sealed partial class WordpressComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://wordpress\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wordpress.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://public-api.wordpress.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://yfrog.com/" />.
    /// </summary>
    public sealed partial class YfrogMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.yfrog\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "yfrog.com";
            yield return "yfrog.us";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.yfrog.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.youtube.com/" />.
    /// </summary>
    public sealed partial class YoutubeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http[s]?://www\.youtube\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.youtube.com";
            yield return "youtube.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.youtube.com/oembed", request);
    }

    partial class OEmbedProxyMetadataProvider
    {
        internal static IEnumerable<Type> CreateKnownHandlerTypes()
        {
            yield return typeof(TwentyThreeMetadataProvider);
            yield return typeof(AlphaAppNetMetadataProvider);
            yield return typeof(AmchartsLiveEditorMetadataProvider);
            yield return typeof(AnimatronMetadataProvider);
            yield return typeof(AnimotoMetadataProvider);
            yield return typeof(AudiosnapsMetadataProvider);
            yield return typeof(BlackfireIoMetadataProvider);
            yield return typeof(BoxofficebuzMetadataProvider);
            yield return typeof(CacooMetadataProvider);
            yield return typeof(CatboatMetadataProvider);
            yield return typeof(ChartblocksMetadataProvider);
            yield return typeof(ChirbitComMetadataProvider);
            yield return typeof(CircuitlabMetadataProvider);
            yield return typeof(CliplandMetadataProvider);
            yield return typeof(ClypMetadataProvider);
            yield return typeof(CodepenMetadataProvider);
            yield return typeof(CodepointsMetadataProvider);
            yield return typeof(CollegehumorMetadataProvider);
            yield return typeof(CoubMetadataProvider);
            yield return typeof(CrowdRankingMetadataProvider);
            yield return typeof(DailymotionMetadataProvider);
            yield return typeof(DailyMileMetadataProvider);
            yield return typeof(DeviantartComMetadataProvider);
            yield return typeof(DidacteMetadataProvider);
            yield return typeof(DipityMetadataProvider);
            yield return typeof(DocdroidMetadataProvider);
            yield return typeof(DocsMetadataProvider);
            yield return typeof(DotsubMetadataProvider);
            yield return typeof(EdocrMetadataProvider);
            yield return typeof(EdumediaSciencesComMetadataProvider);
            yield return typeof(EgliseinfoMetadataProvider);
            yield return typeof(EmbedlyMetadataProvider);
            yield return typeof(EmbedArticlesMetadataProvider);
            yield return typeof(EyrieioMetadataProvider);
            yield return typeof(FacebookMetadataProvider);
            yield return typeof(FlatMetadataProvider);
            yield return typeof(FlickrMetadataProvider);
            yield return typeof(FoxSportsAustraliaMetadataProvider);
            yield return typeof(FramebuzzMetadataProvider);
            yield return typeof(FunnyordieMetadataProvider);
            yield return typeof(GeographMetadataProvider);
            yield return typeof(GettyImagesMetadataProvider);
            yield return typeof(GfycatMetadataProvider);
            yield return typeof(GIPHYMetadataProvider);
            yield return typeof(HuffdufferMetadataProvider);
            yield return typeof(HuluMetadataProvider);
            yield return typeof(IfixitMetadataProvider);
            yield return typeof(IftttMetadataProvider);
            yield return typeof(IndacoMetadataProvider);
            yield return typeof(InfogramMetadataProvider);
            yield return typeof(InoreaderMetadataProvider);
            yield return typeof(InphoodMetadataProvider);
            yield return typeof(InstagramMetadataProvider);
            yield return typeof(IsnareArticlesMetadataProvider);
            yield return typeof(KickstarterMetadataProvider);
            yield return typeof(KidojuMetadataProvider);
            yield return typeof(KitMetadataProvider);
            yield return typeof(KitchenbowlMetadataProvider);
            yield return typeof(KnackiMetadataProvider);
            yield return typeof(LearningappsOrgMetadataProvider);
            yield return typeof(MathembedMetadataProvider);
            yield return typeof(MeetupMetadataProvider);
            yield return typeof(MemeMetadataProvider);
            yield return typeof(MixcloudMetadataProvider);
            yield return typeof(MobyPictureMetadataProvider);
            yield return typeof(ModeloMetadataProvider);
            yield return typeof(MybeweegMetadataProvider);
            yield return typeof(NanooMetadataProvider);
            yield return typeof(NfbCaMetadataProvider);
            yield return typeof(OddsMetadataProvider);
            yield return typeof(OfficeMixMetadataProvider);
            yield return typeof(OfficialFmMetadataProvider);
            yield return typeof(OnAolMetadataProvider);
            yield return typeof(OraTvMetadataProvider);
            yield return typeof(OrbitvuMetadataProvider);
            yield return typeof(OumyMetadataProvider);
            yield return typeof(PasteryMetadataProvider);
            yield return typeof(PixdorMetadataProvider);
            yield return typeof(PollDaddyMetadataProvider);
            yield return typeof(PortMetadataProvider);
            yield return typeof(PortfoliumMetadataProvider);
            yield return typeof(PuntersMetadataProvider);
            yield return typeof(QuizBizMetadataProvider);
            yield return typeof(RapidengageMetadataProvider);
            yield return typeof(RedditMetadataProvider);
            yield return typeof(ReleasewireMetadataProvider);
            yield return typeof(RepubhubMetadataProvider);
            yield return typeof(ReverbnationMetadataProvider);
            yield return typeof(RoomshareMetadataProvider);
            yield return typeof(RumbleMetadataProvider);
            yield return typeof(SapoVideosMetadataProvider);
            yield return typeof(Screen9MetadataProvider);
            yield return typeof(ScreencastComMetadataProvider);
            yield return typeof(ScreenrMetadataProvider);
            yield return typeof(ScribblemapsMetadataProvider);
            yield return typeof(ScribdMetadataProvider);
            yield return typeof(ShortnoteMetadataProvider);
            yield return typeof(ShoudioMetadataProvider);
            yield return typeof(ShowTheWayMetadataProvider);
            yield return typeof(SilkMetadataProvider);
            yield return typeof(SizzleMetadataProvider);
            yield return typeof(SketchfabMetadataProvider);
            yield return typeof(SlideshareMetadataProvider);
            yield return typeof(SmugmugMetadataProvider);
            yield return typeof(SoundcloudMetadataProvider);
            yield return typeof(SoundsgoodMetadataProvider);
            yield return typeof(SpeakerdeckMetadataProvider);
            yield return typeof(SpreakerMetadataProvider);
            yield return typeof(StreamableMetadataProvider);
            yield return typeof(StreamonecloudMetadataProvider);
            yield return typeof(SwayMetadataProvider);
            yield return typeof(TedMetadataProvider);
            yield return typeof(TheySaidSoMetadataProvider);
            yield return typeof(TheNewYorkTimesMetadataProvider);
            yield return typeof(TickcounterMetadataProvider);
            yield return typeof(TopyMetadataProvider);
            yield return typeof(TwitchMetadataProvider);
            yield return typeof(UbideoMetadataProvider);
            yield return typeof(UolMetadataProvider);
            yield return typeof(UstreamMetadataProvider);
            yield return typeof(UttlesMetadataProvider);
            yield return typeof(VeerMetadataProvider);
            yield return typeof(VerseMetadataProvider);
            yield return typeof(VevoMetadataProvider);
            yield return typeof(VideojugMetadataProvider);
            yield return typeof(VidlitMetadataProvider);
            yield return typeof(VimeoMetadataProvider);
            yield return typeof(VineMetadataProvider);
            yield return typeof(VlipsyMetadataProvider);
            yield return typeof(WiredriveMetadataProvider);
            yield return typeof(WizerMeMetadataProvider);
            yield return typeof(WootledMetadataProvider);
            yield return typeof(WordpressComMetadataProvider);
            yield return typeof(YfrogMetadataProvider);
            yield return typeof(YoutubeMetadataProvider);
        }
    }
}
