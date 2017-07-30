using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
namespace MoEmbed.Providers
{

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.23hq.com" />.
    /// </summary>
    public sealed class TwentyThreeMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.23hq\.com/[^/]/photo/");
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
    public sealed class AlphaAppNetMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://alpha\.app\.net/[^/]/post/");
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
    public sealed class AmchartsLiveEditorMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://live\.amcharts\.com/");
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
    public sealed class AnimatronMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.animatron\.com/project/");
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
    public sealed class AnimotoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://animoto\.com/play/");
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
    public sealed class AudiosnapsMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://audiosnaps\.com/k/");
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
    public sealed class BlackfireIoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://blackfire\.io/profiles/[^/]/graph");
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
    public sealed class BoxofficebuzMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://boxofficebuz\.com");
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
    public sealed class CacooMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://cacoo\.com/diagrams/");
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
    public sealed class CatboatMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://img\.catbo\.at/");
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
    public sealed class ChartblocksMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://public\.chartblocks\.com/c/");
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
    public sealed class ChirbitComMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://chirb\.it/");
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
    public sealed class CircuitlabMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.circuitlab\.com/circuit/");
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
    public sealed class CliplandMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.clipland\.com/v/");
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
    public sealed class ClypMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://clyp\.it/");
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
    public sealed class CodepenMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://codepen\.io/");
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
    public sealed class CodepointsMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://codepoints\.net/|https://codepoints\.net/|http://www\.codepoints\.net/|https://www\.codepoints\.net/)");
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
    public sealed class CollegehumorMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.collegehumor\.com/video/");
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
    public sealed class CoubMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://coub\.com/view/");
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
    public sealed class CrowdRankingMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://crowdranking\.com/[^/]/");
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
    public sealed class DailymotionMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.dailymotion\.com/video/");
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
    public sealed class DailyMileMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.dailymile\.com/people/[^/]/entries/");
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
    public sealed class DeviantartComMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.deviantart\.com/art/|http://[^/]\.deviantart\.com/[^/]\#/d|http://fav\.me/|http://sta\.sh/)");
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
    public sealed class DidacteMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://[^/]\.didacte\.com/a/course/");
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
    public sealed class DipityMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.dipity\.com/[^/]/[^/]/");
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
    public sealed class DocdroidMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://[^/]\.docdroid\.net/|http://[^/]\.docdroid\.net/|https://docdro\.id/|http://docdro\.id/)");
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
    public sealed class DocsMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://docs\.com/");
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
    public sealed class DotsubMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://dotsub\.com/view/");
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
    public sealed class EdocrMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://edocr\.com/docs/");
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
    public sealed class EdumediaSciencesComMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.edumedia-sciences\.com/");
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
    public sealed class EgliseinfoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://egliseinfo\.catholique\.fr/");
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
    public sealed class EmbedlyMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://api\.embed\.ly/");
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
    public sealed class EmbedArticlesMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://embedarticles\.com/");
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
    public sealed class EyrieioMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://eyrie\.io/board/");
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
    public sealed class FacebookMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.facebook\.com/");
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
    public sealed class FlatMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://flat\.io/score/");
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
    public sealed class FlickrMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.flickr\.com/photos/");
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
    public sealed class FoxSportsAustraliaMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://fiso\.foxsports\.com\.au/isomorphic-widget/");
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
    public sealed class FramebuzzMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://framebuzz\.com/v/");
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
    public sealed class FunnyordieMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.funnyordie\.com/videos/");
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
    public sealed class GeographMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.geograph\.org\.uk/|http://[^/]\.geograph\.co\.uk/|http://[^/]\.geograph\.ie/|http://[^/]\.wikimedia\.org/[^/]_geograph\.org\.uk_|http://[^/]\.geograph\.org\.gg/|http://[^/]\.geograph\.org\.je/|http://channel-islands\.geograph\.org/|http://channel-islands\.geographs\.org/|http://[^/]\.channel\.geographs\.org/|http://geo-en\.hlipp\.de/|http://geo\.hlipp\.de/|http://germany\.geograph\.org/)");
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
    public sealed class GettyImagesMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://gty\.im/");
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
    public sealed class GfycatMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://gfycat\.com/|http://www\.gfycat\.com/|https://gfycat\.com/|https://www\.gfycat\.com/)");
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
    public sealed class GIPHYMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://giphy\.com/gifs/|http://gph\.is/|https://media\.giphy\.com/media/[^/]/giphy\.gif)");
        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://giphy.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://gyazo.com" />.
    /// </summary>
    public sealed class GyazoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://gyazo\.com/");
        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.gyazo.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://huffduffer.com" />.
    /// </summary>
    public sealed class HuffdufferMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://huffduffer\.com/[^/]/");
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
    public sealed class HuluMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.hulu\.com/watch/");
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
    public sealed class IfixitMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.ifixit\.com/Guide/View/");
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
    public sealed class IftttMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://ifttt\.com/recipes/");
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
    public sealed class IndacoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://player\.indacolive\.com/player/jwp/clients/");
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
    public sealed class InfogramMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://infogr\.am/");
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
    public sealed class InoreaderMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.inoreader\.com/oembed/");
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
    public sealed class InphoodMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.inphood\.com/");
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
    public sealed class InstagramMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://instagram\.com/p/|http://instagr\.am/p/|http://www\.instagram\.com/p/|http://www\.instagr\.am/p/|https://instagram\.com/p/|https://instagr\.am/p/|https://www\.instagram\.com/p/|https://www\.instagr\.am/p/)");
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
    public sealed class IsnareArticlesMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.isnare\.com/");
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
    public sealed class KickstarterMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.kickstarter\.com/projects/");
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
    public sealed class KidojuMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.kidoju\.com/en/x/[^/]/");
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
    public sealed class KitMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://kit\.com/[^/]/");
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
    public sealed class KitchenbowlMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.kitchenbowl\.com/recipe/");
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
    public sealed class KnackiMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://jdr\.knacki\.info/meuh/");
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
    public sealed class LearningappsOrgMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://learningapps\.org/");
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
    public sealed class MathembedMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://mathembed\.com/latex\?inputText=");
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
    public sealed class MeetupMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://meetup\.com/");
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
    public sealed class MemeMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://me\.me/i/");
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
    public sealed class MixcloudMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.mixcloud\.com/[^/]/[^/]/");
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
    public sealed class MobyPictureMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.mobypicture\.com/user/[^/]/view/");
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
    public sealed class ModeloMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://beta\.modelo\.io/embedded/");
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
    public sealed class MybeweegMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://mybeweeg\.com/w/");
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
    public sealed class NanooMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.nanoo\.tv/link/|http://nanoo\.tv/link/|http://[^/]\.nanoo\.pro/link/|http://nanoo\.pro/link/|https://[^/]\.nanoo\.tv/link/|https://nanoo\.tv/link/|https://[^/]\.nanoo\.pro/link/|https://nanoo\.pro/link/)");
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
    public sealed class NfbCaMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.nfb\.ca/film/");
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
    public sealed class OddsMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.odds\.com\.au/");
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
    public sealed class OfficeMixMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://mix\.office\.com/watch/");
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
    public sealed class OfficialFmMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://official\.fm/tracks/");
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
    public sealed class OnAolMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://on\.aol\.com/video/");
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
    public sealed class OraTvMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.ora\.tv/");
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
    public sealed class OrbitvuMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://orbitvu\.co/001/[^/]/ov3601/view|https://orbitvu\.co/001/[^/]/ov3601/[^/]/view|https://orbitvu\.co/001/[^/]/ov3602/[^/]/view|https://orbitvu\.co/001/[^/]/2/orbittour/[^/]/view|https://orbitvu\.co/001/[^/]/1/2/orbittour/[^/]/view|http://orbitvu\.co/001/[^/]/ov3601/view|http://orbitvu\.co/001/[^/]/ov3601/[^/]/view|http://orbitvu\.co/001/[^/]/ov3602/[^/]/view|http://orbitvu\.co/001/[^/]/2/orbittour/[^/]/view|http://orbitvu\.co/001/[^/]/1/2/orbittour/[^/]/view)");
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
    public sealed class OumyMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.oumy\.com/v/");
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
    public sealed class PasteryMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://pastery\.net/|https://pastery\.net/|http://www\.pastery\.net/|https://www\.pastery\.net/)");
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
    public sealed class PixdorMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://store\.pixdor\.com/place-marker-widget/[^/]/show");
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
    public sealed class PollDaddyMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.polldaddy\.com/s/|http://[^/]\.polldaddy\.com/poll/|http://[^/]\.polldaddy\.com/ratings/)");
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
    public sealed class PortMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://app\.sellwithport\.com/\#/buyer/");
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
    public sealed class PortfoliumMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://portfolium\.com/entry/");
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
    public sealed class PuntersMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.punters\.com\.au/");
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
    public sealed class QuizBizMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.quiz\.biz/quizz-[^/]\.html");
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
    public sealed class RapidengageMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://rapidengage\.com/s/");
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
    public sealed class RedditMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://reddit\.com/r/[^/]/comments/[^/]/");
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
    public sealed class ReleasewireMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://rwire\.com/");
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
    public sealed class RepubhubMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://repubhub\.icopyright\.net/freePost\.act\?");
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
    public sealed class ReverbnationMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.reverbnation\.com/");
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
    public sealed class RoomshareMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://roomshare\.jp/post/");
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
    public sealed class RumbleMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://rumble\.com/");
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
    public sealed class SapoVideosMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://videos\.sapo\.pt/");
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
    public sealed class Screen9MetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.screen9\.com/");
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
    public sealed class ScreencastComMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.screencast\.com/");
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
    public sealed class ScreenrMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.screenr\.com/[^/]/");
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
    public sealed class ScribblemapsMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.scribblemaps\.com/maps/view/|https://www\.scribblemaps\.com/maps/view/|http://scribblemaps\.com/maps/view/|https://scribblemaps\.com/maps/view/)");
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
    public sealed class ScribdMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.scribd\.com/doc/");
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
    public sealed class ShortnoteMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://www\.shortnote\.jp/view/notes/");
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
    public sealed class ShoudioMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://shoudio\.com/");
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
    public sealed class ShowTheWayMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://showtheway\.io/to/");
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
    public sealed class SilkMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.silk\.co/explore/|https://[^/]\.silk\.co/explore/|http://[^/]\.silk\.co/s/embed/|https://[^/]\.silk\.co/s/embed/)");
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
    public sealed class SizzleMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://onsizzle\.com/i/");
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
    public sealed class SketchfabMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://sketchfab\.com/models/|https://sketchfab\.com/models/|https://sketchfab\.com/[^/]/folders/)");
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
    public sealed class SlideshareMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.slideshare\.net/[^/]/|http://fr\.slideshare\.net/[^/]/|http://de\.slideshare\.net/[^/]/|http://es\.slideshare\.net/[^/]/|http://pt\.slideshare\.net/[^/]/)");
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
    public sealed class SmugmugMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.smugmug\.com/");
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
    public sealed class SoundcloudMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://soundcloud\.com/");
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
    public sealed class SoundsgoodMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://play\.soundsgood\.co/playlist/");
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
    public sealed class SpeakerdeckMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://speakerdeck\.com/[^/]/");
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
    public sealed class SpreakerMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.spreaker\.com/");
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
    public sealed class StreamableMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://streamable\.com/");
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
    public sealed class StreamonecloudMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://content\.streamonecloud\.net/embed/");
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
    public sealed class SwayMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://sway\.com/");
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
    public sealed class TedMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://ted\.com/talks/");
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
    public sealed class TheySaidSoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://theysaidso\.com/image/");
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
    public sealed class TheNewYorkTimesMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.nytimes\.com/svc/oembed|https://nytimes\.com/|https://[^/]\.nytimes\.com/)");
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
    public sealed class TickcounterMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://www\.tickcounter\.com/countdown/|http://www\.tickcounter\.com/countup/|http://www\.tickcounter\.com/ticker/|http://www\.tickcounter\.com/worldclock/|https://www\.tickcounter\.com/countdown/|https://www\.tickcounter\.com/countup/|https://www\.tickcounter\.com/ticker/|https://www\.tickcounter\.com/worldclock/)");
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
    public sealed class TopyMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.topy\.se/image/");
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
    public sealed class TwitchMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://clips\.twitch\.tv/|https://clips\.twitch\.tv/|http://www\.twitch\.tv/|https://www\.twitch\.tv/|http://twitch\.tv/|https://twitch\.tv/)");
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
    public sealed class UbideoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://player\.ubideo\.com/");
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
    public sealed class UolMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://[^/]\.uol\.com\.br/view/");
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
    public sealed class UstreamMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.ustream\.tv/");
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
    public sealed class UttlesMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://uttles\.com/uttle/");
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
    public sealed class VeerMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://veer\.tv/videos/");
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
    public sealed class VerseMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://verse\.media/");
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
    public sealed class VevoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.vevo\.com/");
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
    public sealed class VideojugMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://www\.videojug\.com/film/");
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
    public sealed class VidlitMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://vidl\.it/");
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
    public sealed class VimeoMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vimeo\.com/");
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
    public sealed class VineMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://vine\.co/v/");
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
    public sealed class VlipsyMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://vlipsy\.com/");
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
    public sealed class WiredriveMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"https://[^/]\.wiredrive\.com/");
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
    public sealed class WizerMeMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://[^/]\.wizer\.me/learn/|https://[^/]\.wizer\.me/learn/|http://[^/]\.wizer\.me/preview/|https://[^/]\.wizer\.me/preview/)");
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
    public sealed class WootledMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.wootled\.com/");
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
    public sealed class WordpressComMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://wordpress\.com/");
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
    public sealed class YfrogMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"http://[^/]\.yfrog\.com/");
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
    public sealed class YoutubeMetadataProvider : RemoteMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.youtube\.com/");
        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://www.youtube.com/oembed", request);
    }
    partial class RemoteMetadataProvider
    {
        public static IEnumerable<RemoteMetadataProvider> CreateKnownHandlers()
        {
            yield return new TwentyThreeMetadataProvider();
            yield return new AlphaAppNetMetadataProvider();
            yield return new AmchartsLiveEditorMetadataProvider();
            yield return new AnimatronMetadataProvider();
            yield return new AnimotoMetadataProvider();
            yield return new AudiosnapsMetadataProvider();
            yield return new BlackfireIoMetadataProvider();
            yield return new BoxofficebuzMetadataProvider();
            yield return new CacooMetadataProvider();
            yield return new CatboatMetadataProvider();
            yield return new ChartblocksMetadataProvider();
            yield return new ChirbitComMetadataProvider();
            yield return new CircuitlabMetadataProvider();
            yield return new CliplandMetadataProvider();
            yield return new ClypMetadataProvider();
            yield return new CodepenMetadataProvider();
            yield return new CodepointsMetadataProvider();
            yield return new CollegehumorMetadataProvider();
            yield return new CoubMetadataProvider();
            yield return new CrowdRankingMetadataProvider();
            yield return new DailymotionMetadataProvider();
            yield return new DailyMileMetadataProvider();
            yield return new DeviantartComMetadataProvider();
            yield return new DidacteMetadataProvider();
            yield return new DipityMetadataProvider();
            yield return new DocdroidMetadataProvider();
            yield return new DocsMetadataProvider();
            yield return new DotsubMetadataProvider();
            yield return new EdocrMetadataProvider();
            yield return new EdumediaSciencesComMetadataProvider();
            yield return new EgliseinfoMetadataProvider();
            yield return new EmbedlyMetadataProvider();
            yield return new EmbedArticlesMetadataProvider();
            yield return new EyrieioMetadataProvider();
            yield return new FacebookMetadataProvider();
            yield return new FlatMetadataProvider();
            yield return new FlickrMetadataProvider();
            yield return new FoxSportsAustraliaMetadataProvider();
            yield return new FramebuzzMetadataProvider();
            yield return new FunnyordieMetadataProvider();
            yield return new GeographMetadataProvider();
            yield return new GettyImagesMetadataProvider();
            yield return new GfycatMetadataProvider();
            yield return new GIPHYMetadataProvider();
            yield return new GyazoMetadataProvider();
            yield return new HuffdufferMetadataProvider();
            yield return new HuluMetadataProvider();
            yield return new IfixitMetadataProvider();
            yield return new IftttMetadataProvider();
            yield return new IndacoMetadataProvider();
            yield return new InfogramMetadataProvider();
            yield return new InoreaderMetadataProvider();
            yield return new InphoodMetadataProvider();
            yield return new InstagramMetadataProvider();
            yield return new IsnareArticlesMetadataProvider();
            yield return new KickstarterMetadataProvider();
            yield return new KidojuMetadataProvider();
            yield return new KitMetadataProvider();
            yield return new KitchenbowlMetadataProvider();
            yield return new KnackiMetadataProvider();
            yield return new LearningappsOrgMetadataProvider();
            yield return new MathembedMetadataProvider();
            yield return new MeetupMetadataProvider();
            yield return new MemeMetadataProvider();
            yield return new MixcloudMetadataProvider();
            yield return new MobyPictureMetadataProvider();
            yield return new ModeloMetadataProvider();
            yield return new MybeweegMetadataProvider();
            yield return new NanooMetadataProvider();
            yield return new NfbCaMetadataProvider();
            yield return new OddsMetadataProvider();
            yield return new OfficeMixMetadataProvider();
            yield return new OfficialFmMetadataProvider();
            yield return new OnAolMetadataProvider();
            yield return new OraTvMetadataProvider();
            yield return new OrbitvuMetadataProvider();
            yield return new OumyMetadataProvider();
            yield return new PasteryMetadataProvider();
            yield return new PixdorMetadataProvider();
            yield return new PollDaddyMetadataProvider();
            yield return new PortMetadataProvider();
            yield return new PortfoliumMetadataProvider();
            yield return new PuntersMetadataProvider();
            yield return new QuizBizMetadataProvider();
            yield return new RapidengageMetadataProvider();
            yield return new RedditMetadataProvider();
            yield return new ReleasewireMetadataProvider();
            yield return new RepubhubMetadataProvider();
            yield return new ReverbnationMetadataProvider();
            yield return new RoomshareMetadataProvider();
            yield return new RumbleMetadataProvider();
            yield return new SapoVideosMetadataProvider();
            yield return new Screen9MetadataProvider();
            yield return new ScreencastComMetadataProvider();
            yield return new ScreenrMetadataProvider();
            yield return new ScribblemapsMetadataProvider();
            yield return new ScribdMetadataProvider();
            yield return new ShortnoteMetadataProvider();
            yield return new ShoudioMetadataProvider();
            yield return new ShowTheWayMetadataProvider();
            yield return new SilkMetadataProvider();
            yield return new SizzleMetadataProvider();
            yield return new SketchfabMetadataProvider();
            yield return new SlideshareMetadataProvider();
            yield return new SmugmugMetadataProvider();
            yield return new SoundcloudMetadataProvider();
            yield return new SoundsgoodMetadataProvider();
            yield return new SpeakerdeckMetadataProvider();
            yield return new SpreakerMetadataProvider();
            yield return new StreamableMetadataProvider();
            yield return new StreamonecloudMetadataProvider();
            yield return new SwayMetadataProvider();
            yield return new TedMetadataProvider();
            yield return new TheySaidSoMetadataProvider();
            yield return new TheNewYorkTimesMetadataProvider();
            yield return new TickcounterMetadataProvider();
            yield return new TopyMetadataProvider();
            yield return new TwitchMetadataProvider();
            yield return new UbideoMetadataProvider();
            yield return new UolMetadataProvider();
            yield return new UstreamMetadataProvider();
            yield return new UttlesMetadataProvider();
            yield return new VeerMetadataProvider();
            yield return new VerseMetadataProvider();
            yield return new VevoMetadataProvider();
            yield return new VideojugMetadataProvider();
            yield return new VidlitMetadataProvider();
            yield return new VimeoMetadataProvider();
            yield return new VineMetadataProvider();
            yield return new VlipsyMetadataProvider();
            yield return new WiredriveMetadataProvider();
            yield return new WizerMeMetadataProvider();
            yield return new WootledMetadataProvider();
            yield return new WordpressComMetadataProvider();
            yield return new YfrogMetadataProvider();
            yield return new YoutubeMetadataProvider();
        }
    }
}