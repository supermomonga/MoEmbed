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
    /// Handles oEmbed request for <see href="https://abraia.me" />.
    /// </summary>
    public sealed partial class AbraiaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://store\.abraia\.me/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "store.abraia.me";
            yield return "abraia.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.abraia.me/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://embed.acast.com" />.
    /// </summary>
    public sealed partial class AcastMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://play\.acast\.com/s/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.acast.com";
            yield return "acast.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.acast.com/v1/embed-player", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://secure.actblue.com" />.
    /// </summary>
    public sealed partial class ActblueMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://secure\.actblue\.com/donate/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "secure.actblue.com";
            yield return "actblue.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://secure.actblue.com/cf/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://adilo.bigcommand.com" />.
    /// </summary>
    public sealed partial class AdiloMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://adilo\.bigcommand\.com/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "adilo.bigcommand.com";
            yield return "bigcommand.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://adilo.bigcommand.com/web/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.afreecatv.com" />.
    /// </summary>
    public sealed partial class AfreecatvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://v\.afree\.ca/ST/|https://vod\.afreecatv\.com/ST/|https://vod\.afreecatv\.com/PLAYER/STATION/|https://play\.afreecatv\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "v.afree.ca";
            yield return "afree.ca";
            yield return "vod.afreecatv.com";
            yield return "afreecatv.com";
            yield return "play.afreecatv.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://openapi.afreecatv.com/oembed/embedinfo", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://altium.com" />.
    /// </summary>
    public sealed partial class AltiumMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://altium\.com/viewer/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "altium.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://viewer.altium.com/shell/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.altrulabs.com" />.
    /// </summary>
    public sealed partial class AltrulabsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.altrulabs\.com/.*/.*\?answer_id=");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.altrulabs.com";
            yield return "altrulabs.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.altrulabs.com/api/v1/social/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://live.amcharts.com/" />.
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
            => GetProviderUriCore("https://live.amcharts.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://amtraker.com" />.
    /// </summary>
    public sealed partial class AmtrakerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://amtraker\.com/trains/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "amtraker.com";
            yield return "beta.amtraker.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.amtraker.com/v2/oembed", request);
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
    /// Handles oEmbed request for <see href="https://anniemusic.app" />.
    /// </summary>
    public sealed partial class AnniemusicMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://anniemusic\.app/t/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "anniemusic.app";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.anniemusic.app/api/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://app.archivos.digital" />.
    /// </summary>
    public sealed partial class ArchivosMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.archivos\.digital/app/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.archivos.digital";
            yield return "archivos.digital";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.archivos.digital/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://audioboom.com" />.
    /// </summary>
    public sealed partial class AudioboomMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://audioboom\.com/channels/|https://audioboom\.com/channel/|https://audioboom\.com/playlists/|https://audioboom\.com/podcasts/|https://audioboom\.com/podcast/|https://audioboom\.com/posts/|https://audioboom\.com/episodes/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "audioboom.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://audioboom.com/publishing/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://audioclip.naver.com" />.
    /// </summary>
    public sealed partial class AudioclipMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://audioclip\.naver\.com/channels/.*/clips/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "audioclip.naver.com";
            yield return "naver.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://audioclip.naver.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://audiomack.com" />.
    /// </summary>
    public sealed partial class AudiomackMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://audiomack\.com/.*/song/|https://audiomack\.com/.*/album/|https://audiomack\.com/.*/playlist/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "audiomack.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://audiomack.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://audiomeans.fr" />.
    /// </summary>
    public sealed partial class AudiomeansMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://podcasts\.audiomeans\.fr/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "podcasts.audiomeans.fr";
            yield return "audiomeans.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://podcasts.audiomeans.fr/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.avocode.com/" />.
    /// </summary>
    public sealed partial class AvocodeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.avocode\.com/view/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.avocode.com";
            yield return "avocode.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://stage-embed.avocode.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://backtracks.fm" />.
    /// </summary>
    public sealed partial class BacktracksMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://backtracks\.fm/.*/.*/e/|https://backtracks\.fm/.*/s/.*/|https://backtracks\.fm/.*/.*/.*/.*/e/.*/|https://backtracks\.fm/|http://backtracks\.fm/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "backtracks.fm";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://backtracks.fm/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://beams.fm" />.
    /// </summary>
    public sealed partial class BeamsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://beams\.fm/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "beams.fm";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.beams.fm/oEmbed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.beautiful.ai/" />.
    /// </summary>
    public sealed partial class BeautifulMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.beautiful\.ai/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.beautiful.ai";
            yield return "beautiful.ai";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.beautiful.ai/api/oembed", request);
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
    /// Handles oEmbed request for <see href="https://blogcast.host/" />.
    /// </summary>
    public sealed partial class BlogcastMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://blogcast\.host/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "blogcast.host";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://blogcast.host/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.bookingmood.com" />.
    /// </summary>
    public sealed partial class BookingmoodMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.bookingmood\.com/embed/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.bookingmood.com";
            yield return "bookingmood.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://bookingmood.com/api/oembed", request);
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
    /// Handles oEmbed request for <see href="https://view.briovr.com/" />.
    /// </summary>
    public sealed partial class BriovrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://view\.briovr\.com/api/v1/worlds/oembed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "view.briovr.com";
            yield return "briovr.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://view.briovr.com/api/v1/worlds/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.bumper.com" />.
    /// </summary>
    public sealed partial class BumperMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.bumper\.com/oembed/bumper");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.bumper.com";
            yield return "bumper.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.bumper.com/oembed/bumper", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://buttondown.email/" />.
    /// </summary>
    public sealed partial class ButtondownMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://buttondown\.email/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "buttondown.email";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://buttondown.email/embed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://cmc.byzart.eu" />.
    /// </summary>
    public sealed partial class ByzartMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://cmc\.byzart\.eu/files/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "cmc.byzart.eu";
            yield return "byzart.eu";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://cmc.byzart.eu/oembed/", request);
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
    /// Handles oEmbed request for <see href="http://www.ceros.com/" />.
    /// </summary>
    public sealed partial class CerosMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://view\.ceros\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "view.ceros.com";
            yield return "ceros.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://view.ceros.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://chainflix.net" />.
    /// </summary>
    public sealed partial class ChainflixMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://chainflix\.net/video/|https://chainflix\.net/video/embed/|https://.*\.chainflix\.net/video/|https://.*\.chainflix\.net/video/embed/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "chainflix.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.chainflix.net/video/oembed", request);
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
    /// Handles oEmbed request for <see href="https://chroco.ooo/" />.
    /// </summary>
    public sealed partial class ChrocoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://chroco\.ooo/mypage/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "chroco.ooo";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://chroco.ooo/embed", request);
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
    /// Handles oEmbed request for <see href="https://ilovecoco.video" />.
    /// </summary>
    public sealed partial class CocoCorpMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.ilovecoco\.video/.*/embed");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.ilovecoco.video";
            yield return "ilovecoco.video";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://app.ilovecoco.video/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.codehs.com" />.
    /// </summary>
    public sealed partial class CodehsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://codehs\.com/editor/share_abacus/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "codehs.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://codehs.com/api/sharedprogram/1/oembed/", request);
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
            => GetProviderUriCore("https://codepen.io/api/oembed", request);
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
    /// Handles oEmbed request for <see href="https://codesandbox.io" />.
    /// </summary>
    public sealed partial class CodesandboxMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://codesandbox\.io/s/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "codesandbox.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://codesandbox.io/oembed", request);
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
    /// Handles oEmbed request for <see href="https://commaful.com" />.
    /// </summary>
    public sealed partial class CommafulMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://commaful\.com/play/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "commaful.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://commaful.com/api/oembed/", request);
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
    /// Handles oEmbed request for <see href="https://crumb.sh" />.
    /// </summary>
    public sealed partial class CrumbsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://crumb\.sh/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "crumb.sh";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://crumb.sh/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://cueup.io" />.
    /// </summary>
    public sealed partial class CueupMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://cueup\.io/user/.*/sounds/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "cueup.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://gql.cueup.io/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://curated.co/" />.
    /// </summary>
    public sealed partial class CuratedMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.curated\.co/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "curated.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.curated.co/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://customerdb.com/" />.
    /// </summary>
    public sealed partial class CustomerdbMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.customerdb\.com/share/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.customerdb.com";
            yield return "customerdb.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.customerdb.com/embed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.dadan.io" />.
    /// </summary>
    public sealed partial class DadanMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.dadan\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.dadan.io";
            yield return "dadan.io";
            yield return "stage.dadan.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.dadan.io/api/video/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.dailymotion.com" />.
    /// </summary>
    public sealed partial class DailymotionMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.dailymotion\.com/video/");

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
            => GetProviderUriCore("https://www.dailymotion.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://dalexni.com/" />.
    /// </summary>
    public sealed partial class DalexniMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://dalexni\.com/i/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "dalexni.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://dalexni.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.datawrapper.de" />.
    /// </summary>
    public sealed partial class DatawrapperMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://datawrapper\.dwcdn\.net/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "datawrapper.dwcdn.net";
            yield return "dwcdn.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.datawrapper.de/v3/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.deseret.com" />.
    /// </summary>
    public sealed partial class DeseretnewsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.deseret\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "deseret.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.deseret.com/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://www.deviantart.com" />.
    /// </summary>
    public sealed partial class DeviantartComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.deviantart\.com/art/|http://.*\.deviantart\.com/.*\#/d|http://fav\.me/|http://sta\.sh/|https://.*\.deviantart\.com/art/|https://.*\.deviantart\.com/.*/art/|https://sta\.sh/|https://.*\.deviantart\.com/.*\#/d)");

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
    /// Handles oEmbed request for <see href="https://www.ultimedia.com/" />.
    /// </summary>
    public sealed partial class DigitekaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.ultimedia\.com/central/video/edit/id/.*/topic_id/.*/|https://www\.ultimedia\.com/default/index/videogeneric/id/.*/showtitle/1/viewnc/1|https://www\.ultimedia\.com/default/index/videogeneric/id/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.ultimedia.com";
            yield return "ultimedia.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.ultimedia.com/api/search/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.docdroid.net/" />.
    /// </summary>
    public sealed partial class DocdroidMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://.*\.docdroid\.net/|http://.*\.docdroid\.net/|https://docdro\.id/|http://docdro\.id/|https://.*\.docdroid\.com/|http://.*\.docdroid\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "docdroid.net";
            yield return "docdro.id";
            yield return "docdroid.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.docdroid.net/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://docswell.com" />.
    /// </summary>
    public sealed partial class DocswellMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://docswell\.com/.*/|https://docswell\.com/.*/|http://www\.docswell\.com/.*/|https://www\.docswell\.com/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "docswell.com";
            yield return "www.docswell.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.docswell.com/service/oembed", request);
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
    /// Handles oEmbed request for <see href="https://dreambroker.com" />.
    /// </summary>
    public sealed partial class DreambrokerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.dreambroker\.com/channel/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.dreambroker.com";
            yield return "dreambroker.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://dreambroker.com/channel/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://d.tube/" />.
    /// </summary>
    public sealed partial class DtubeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://d\.tube/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "d.tube";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.d.tube/oembed", request);
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
    /// Handles oEmbed request for <see href="https://embedery.com/" />.
    /// </summary>
    public sealed partial class EmbederyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://embedery\.com/widget/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "embedery.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embedery.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://music.enystre.com" />.
    /// </summary>
    public sealed partial class EnystreMusicMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://music\.enystre\.com/lyrics/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "music.enystre.com";
            yield return "enystre.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://music.enystre.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.ethfiddle.com/" />.
    /// </summary>
    public sealed partial class EthfiddleMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://ethfiddle\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ethfiddle.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://ethfiddle.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://eventlive.pro" />.
    /// </summary>
    public sealed partial class EventliveMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://evt\.live/|https://evt\.live/.*/|https://live\.eventlive\.pro/|https://live\.eventlive\.pro/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "evt.live";
            yield return "live.eventlive.pro";
            yield return "eventlive.pro";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://evt.live/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://everviz.com" />.
    /// </summary>
    public sealed partial class EvervizMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.everviz\.com/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.everviz.com";
            yield return "everviz.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.everviz.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://ex.co" />.
    /// </summary>
    public sealed partial class ExcoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.ex\.co/stories/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.ex.co";
            yield return "ex.co";
            yield return "www.playbuzz.com";
            yield return "playbuzz.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.ex.co/item", request);
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
            => GetProviderUriCore("https://graph.facebook.com/v10.0/oembed_page", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://app.getfader.com" />.
    /// </summary>
    public sealed partial class FaderMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.getfader\.com/projects/.*/publish");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.getfader.com";
            yield return "getfader.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.getfader.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://faithlifetv.com" />.
    /// </summary>
    public sealed partial class FaithlifetvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://faithlifetv\.com/items/|https://faithlifetv\.com/items/resource/.*/|https://faithlifetv\.com/media/|https://faithlifetv\.com/media/assets/|https://faithlifetv\.com/media/resource/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "faithlifetv.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://faithlifetv.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://fireworktv.com/" />.
    /// </summary>
    public sealed partial class FireworktvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.fireworktv\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "fireworktv.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.fireworktv.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.fite.tv/" />.
    /// </summary>
    public sealed partial class FiteMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.fite\.tv/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.fite.tv";
            yield return "fite.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.fite.tv/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.flickr.com/" />.
    /// </summary>
    public sealed partial class FlickrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.flickr\.com/photos/|http://flic\.kr/p/|https://.*\.flickr\.com/photos/|https://flic\.kr/p/|https://.*\..*\.flickr\.com/.*/|http://.*\..*\.flickr\.com/.*/)");

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
            => GetProviderUriCore("https://www.flickr.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://flourish.studio/" />.
    /// </summary>
    public sealed partial class FlourishMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://public\.flourish\.studio/visualisation/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "public.flourish.studio";
            yield return "flourish.studio";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.flourish.studio/api/v1/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.framer.com" />.
    /// </summary>
    public sealed partial class FramerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://framer\.com/share/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "framer.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.framer.com/web/oembed", request);
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
    /// Handles oEmbed request for <see href="https://getshow.io/" />.
    /// </summary>
    public sealed partial class GetshowMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://getshow\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "getshow.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://api.getshow.io/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.gifnote.com/" />.
    /// </summary>
    public sealed partial class GifnoteMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.gifnote\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.gifnote.com";
            yield return "gifnote.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.gifnote.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://giphy.com" />.
    /// </summary>
    public sealed partial class GIPHYMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://giphy\.com/gifs/|https://giphy\.com/clips/|http://gph\.is/|https://media\.giphy\.com/media/.*/giphy\.gif)");

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
            => GetProviderUriCore("https://giphy.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://gloria.tv/" />.
    /// </summary>
    public sealed partial class GloriatvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://gloria\.tv/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "gloria.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://gloria.tv/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.gmetri.com/" />.
    /// </summary>
    public sealed partial class GmetriMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://view\.gmetri\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "view.gmetri.com";
            yield return "gmetri.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.gmetri.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.gong.io/" />.
    /// </summary>
    public sealed partial class GongMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.gong\.io/call\?id=");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.gong.io";
            yield return "gong.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.gong.io/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://grain.com" />.
    /// </summary>
    public sealed partial class GrainMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://grain\.co/highlight/|https://grain\.co/share/|https://grain\.com/share/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "grain.co";
            yield return "grain.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.grain.com/_/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://gtchannel.com" />.
    /// </summary>
    public sealed partial class GtchannelMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://gtchannel\.com/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "gtchannel.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.luminery.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://hash.ai" />.
    /// </summary>
    public sealed partial class HASHMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://core\.hash\.ai/@");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "core.hash.ai";
            yield return "hash.ai";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.hash.ai/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://hearthis.at/" />.
    /// </summary>
    public sealed partial class HearthisMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://hearthis\.at/.*/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "hearthis.at";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://hearthis.at/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://heyzine.com" />.
    /// </summary>
    public sealed partial class HeyzineMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://heyzine\.com/flip-book/|https://.*\.hflip\.co/|https://.*\.aflip\.in/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "heyzine.com";
            yield return "hflip.co";
            yield return "aflip.in";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://heyzine.com/api1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.hihaho.com" />.
    /// </summary>
    public sealed partial class HihahoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://player\.hihaho\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "player.hihaho.com";
            yield return "hihaho.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://player.hihaho.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://hippovideo.io" />.
    /// </summary>
    public sealed partial class HippovideoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://.*\.hippovideo\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "hippovideo.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.hippovideo.io/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://homey.app" />.
    /// </summary>
    public sealed partial class HomeyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://homey\.app/f/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "homey.app";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://homey.app/api/oembed/flow", request);
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
    /// Handles oEmbed request for <see href="https://idomoo.com/" />.
    /// </summary>
    public sealed partial class IdomooMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.idomoo\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "idomoo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.idomoo.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.iheart.com" />.
    /// </summary>
    public sealed partial class IheartradioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.iheart\.com/podcast/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.iheart.com";
            yield return "iheart.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.iheart.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://imenupro.com" />.
    /// </summary>
    public sealed partial class ImenuproMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://qr\.imenupro\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "qr.imenupro.com";
            yield return "imenupro.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://qr.imenupro.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://incredible.dev" />.
    /// </summary>
    public sealed partial class IncredibleMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://incredible\.dev/watch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "incredible.dev";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.incredible.dev/oembed", request);
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
    /// Handles oEmbed request for <see href="https://infogram.com/" />.
    /// </summary>
    public sealed partial class InfogramMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://infogram\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "infogram.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://infogram.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://infoveave.net/" />.
    /// </summary>
    public sealed partial class InfoveaveMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.infoveave\.net/E/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "infoveave.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://infoveave.net/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.injurymap.com/" />.
    /// </summary>
    public sealed partial class InjurymapMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.injurymap\.com/exercises/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.injurymap.com";
            yield return "injurymap.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.injurymap.com/services/oembed", request);
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
        private static readonly Regex _UriPattern = new Regex(@"^(http://instagram\.com/.*/p/|http://www\.instagram\.com/.*/p/|https://instagram\.com/.*/p/|https://www\.instagram\.com/.*/p/|http://instagram\.com/p/|http://instagr\.am/p/|http://www\.instagram\.com/p/|http://www\.instagr\.am/p/|https://instagram\.com/p/|https://instagr\.am/p/|https://www\.instagram\.com/p/|https://www\.instagr\.am/p/|http://instagram\.com/tv/|http://instagr\.am/tv/|http://www\.instagram\.com/tv/|http://www\.instagr\.am/tv/|https://instagram\.com/tv/|https://instagr\.am/tv/|https://www\.instagram\.com/tv/|https://www\.instagr\.am/tv/|http://www\.instagram\.com/reel/|https://www\.instagram\.com/reel/|http://instagram\.com/reel/|https://instagram\.com/reel/|http://instagr\.am/reel/|https://instagr\.am/reel/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "instagram.com";
            yield return "www.instagram.com";
            yield return "instagr.am";
            yield return "www.instagr.am";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://graph.facebook.com/v10.0/instagram_oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.insticator.com/" />.
    /// </summary>
    public sealed partial class InsticatorMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://ppa\.insticator\.com/embed-unit/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ppa.insticator.com";
            yield return "insticator.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.insticator.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://issuu.com/" />.
    /// </summary>
    public sealed partial class IssuuMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://issuu\.com/.*/docs/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "issuu.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://issuu.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://jovian.com/" />.
    /// </summary>
    public sealed partial class JovianMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://jovian\.ml/|https://jovian\.ml/viewer|https://.*\.jovian\.ml/|https://jovian\.ai/|https://jovian\.ai/viewer|https://.*\.jovian\.ai/|https://jovian\.com/|https://jovian\.com/viewer|https://.*\.jovian\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "jovian.ml";
            yield return "jovian.ai";
            yield return "jovian.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://api.jovian.com/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://tv.kakao.com/" />.
    /// </summary>
    public sealed partial class KakaotvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://tv\.kakao\.com/channel/.*/cliplink/|https://tv\.kakao\.com/m/channel/.*/cliplink/|https://tv\.kakao\.com/channel/v/|https://tv\.kakao\.com/channel/.*/livelink/|https://tv\.kakao\.com/m/channel/.*/livelink/|https://tv\.kakao\.com/channel/l/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "tv.kakao.com";
            yield return "kakao.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://tv.kakao.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://kirim.email/" />.
    /// </summary>
    public sealed partial class KirimemailMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://halaman\.email/form/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "halaman.email";
            yield return "aplikasi.kirim.email";
            yield return "kirim.email";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://halaman.email/service/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://kit.co/" />.
    /// </summary>
    public sealed partial class KitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://kit\.co/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "kit.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.kit.co/oembed", request);
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
    /// Handles oEmbed request for <see href="https://kmdr.sh" />.
    /// </summary>
    public sealed partial class KmdrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.kmdr\.sh/h/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.kmdr.sh";
            yield return "kmdr.sh";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.kmdr.sh/services/oembed", request);
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
    /// Handles oEmbed request for <see href="https://knowledgepad.co/" />.
    /// </summary>
    public sealed partial class KnowledgepadMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://knowledgepad\.co/\#/knowledge/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "knowledgepad.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.spoonacular.com/knowledge/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://kooapp.com" />.
    /// </summary>
    public sealed partial class KooappMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.kooapp\.com/koo/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "kooapp.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.kooapp.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://kurozora.app/" />.
    /// </summary>
    public sealed partial class KurozoraMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://kurozora\.app/episodes");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "kurozora.app";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://kurozora.app/oembed", request);
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
    /// Handles oEmbed request for <see href="https://place.line.me" />.
    /// </summary>
    public sealed partial class LineplaceMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://place\.line\.me/businesses/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "place.line.me";
            yield return "line.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://place.line.me/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://livestream.com/" />.
    /// </summary>
    public sealed partial class LivestreamMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://livestream\.com/accounts/.*/events/|https://livestream\.com/accounts/.*/events/.*/videos/|https://livestream\.com/.*/events/|https://livestream\.com/.*/events/.*/videos/|https://livestream\.com/.*/|https://livestream\.com/.*/.*/videos/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "livestream.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://livestream.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://lottiefiles.com/" />.
    /// </summary>
    public sealed partial class LottiefilesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://lottiefiles\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "lottiefiles.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.lottiefiles.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://ludus.one" />.
    /// </summary>
    public sealed partial class LudusMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.ludus\.one/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.ludus.one";
            yield return "ludus.one";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.ludus.one/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://latd.com" />.
    /// </summary>
    public sealed partial class LumiereMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.lumiere\.is/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "lumiere.is";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://admin.lumiere.is/api/services/oembed", request);
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
    /// Handles oEmbed request for <see href="https://matterport.com/" />.
    /// </summary>
    public sealed partial class MatterportMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://matterport\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "matterport.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://my.matterport.com/api/v1/models/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mdstrm.com/" />.
    /// </summary>
    public sealed partial class MediastreamMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://mdstrm\.com/embed/|https://mdstrm\.com/live-stream/|https://mdstrm\.com/image/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mdstrm.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mdstrm.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://medienarchiv.zhdk.ch/" />.
    /// </summary>
    public sealed partial class MedienarchivZhdkMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://medienarchiv\.zhdk\.ch/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "medienarchiv.zhdk.ch";
            yield return "zhdk.ch";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://medienarchiv.zhdk.ch/oembed", request);
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
    /// Handles oEmbed request for <see href="https://mermaid.ink" />.
    /// </summary>
    public sealed partial class MermaidInkMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://mermaid\.ink/img/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mermaid.ink";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mermaid.ink/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://stream.microsoft.com" />.
    /// </summary>
    public sealed partial class MicrosoftStreamMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.microsoftstream\.com/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "microsoftstream.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://web.microsoftstream.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.minervaknows.com" />.
    /// </summary>
    public sealed partial class MinervaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.minervaknows\.com/featured-recipes/|https://www\.minervaknows\.com/themes/|https://www\.minervaknows\.com/themes/.*/recipes/|https://app\.minervaknows\.com/recipes/|https://app\.minervaknows\.com/recipes/.*/follow)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.minervaknows.com";
            yield return "minervaknows.com";
            yield return "app.minervaknows.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.minervaknows.com", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://minesweeper.today/" />.
    /// </summary>
    public sealed partial class MinesweeperTodayMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://minesweeper\.today/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "minesweeper.today";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://minesweeper.today/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://miro.com/" />.
    /// </summary>
    public sealed partial class MiroMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://miro\.com/app/board/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "miro.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://miro.com/api/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mixcloud.com/" />.
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
            => GetProviderUriCore("https://www.mixcloud.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mixpanel.com/" />.
    /// </summary>
    public sealed partial class MixpanelMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://mixpanel\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mixpanel.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mixpanel.com/api/app/embed/oembed/", request);
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
    /// Handles oEmbed request for <see href="https://musicboxmaniacs.com/" />.
    /// </summary>
    public sealed partial class MusicboxmaniacsComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://musicboxmaniacs\.com/explore/melody/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "musicboxmaniacs.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://musicboxmaniacs.com/embed/", request);
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
    /// Handles oEmbed request for <see href="https://namchey.com" />.
    /// </summary>
    public sealed partial class NamcheyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://namchey\.com/embeds/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "namchey.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://namchey.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.nb.no/" />.
    /// </summary>
    public sealed partial class NasjonalbiblioteketMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.nb\.no/items/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.nb.no";
            yield return "nb.no";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.nb.no/catalog/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://naturalatlas.com/" />.
    /// </summary>
    public sealed partial class NaturalatlasMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://naturalatlas\.com/|https://naturalatlas\.com/.*/|https://naturalatlas\.com/.*/.*/|https://naturalatlas\.com/.*/.*/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "naturalatlas.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://naturalatlas.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://ndla.no" />.
    /// </summary>
    public sealed partial class NdlaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://ndla\.no/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ndla.no";
            yield return "liste.ndla.no";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://liste.ndla.no/oembed", request);
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
    /// Handles oEmbed request for <see href="https://nopaste.ml" />.
    /// </summary>
    public sealed partial class NopasteMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://nopaste\.ml/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "nopaste.ml";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.nopaste.ml", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://observablehq.com" />.
    /// </summary>
    public sealed partial class ObservableMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://observablehq\.com/@.*/|https://observablehq\.com/d/|https://observablehq\.com/embed/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "observablehq.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.observablehq.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://odysee.com" />.
    /// </summary>
    public sealed partial class OdyseeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://odysee\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "odysee.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://odysee.com/$/oembed", request);
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
    /// Handles oEmbed request for <see href="https://omniscope.me/" />.
    /// </summary>
    public sealed partial class OmniscopeMeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://omniscope\.me/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "omniscope.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://omniscope.me/_global_/oembed/json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://omnystudio.com" />.
    /// </summary>
    public sealed partial class OmnystudioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://omny\.fm/shows/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "omny.fm";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://omny.fm/oembed", request);
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
    /// Handles oEmbed request for <see href="https://outplayed.tv/" />.
    /// </summary>
    public sealed partial class OutplayedTvMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://outplayed\.tv/media/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "outplayed.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://outplayed.tv/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://overflow.io" />.
    /// </summary>
    public sealed partial class OverflowIoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://overflow\.io/s/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "overflow.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://overflow.io/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.oz.com/" />.
    /// </summary>
    public sealed partial class OzMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.oz\.com/.*/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.oz.com";
            yield return "oz.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://core.oz.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://padlet.com/" />.
    /// </summary>
    public sealed partial class PadletMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://padlet\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "padlet.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://padlet.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://pandavideo.com/" />.
    /// </summary>
    public sealed partial class PandavideoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://pandavideo\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "pandavideo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api-v2.pandavideo.com.br/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.picturelfy.com/" />.
    /// </summary>
    public sealed partial class PicturelfyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://www\.picturelfy\.com/p/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.picturelfy.com";
            yield return "picturelfy.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.picturelfy.com/service/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://builder.pikasso.xyz" />.
    /// </summary>
    public sealed partial class PikassoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.builder\.pikasso\.xyz/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "builder.pikasso.xyz";
            yield return "pikasso.xyz";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://builder.pikasso.xyz/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.pingvp.com/" />.
    /// </summary>
    public sealed partial class PingvpMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.pingvp\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.pingvp.com";
            yield return "pingvp.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://beta.pingvp.com.kpnis.nl/p/oembed.php", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href=": https://www.pinpoll.com/products/tools" />.
    /// </summary>
    public sealed partial class PinpollMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://tools\.pinpoll\.com/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "tools.pinpoll.com";
            yield return "pinpoll.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://tools.pinpoll.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.pinterest.com" />.
    /// </summary>
    public sealed partial class PinterestMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.pinterest\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.pinterest.com";
            yield return "pinterest.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithoutFormat("https://www.pinterest.com/oembed.json", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.pitchhub.com/" />.
    /// </summary>
    public sealed partial class PitchhubMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://player\.pitchhub\.com/en/public/player/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "player.pitchhub.com";
            yield return "pitchhub.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://player.pitchhub.com/en/public/oembed", request);
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
    /// Handles oEmbed request for <see href="http://plusdocs.com" />.
    /// </summary>
    public sealed partial class PlusdocsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://app\.plusdocs\.com/.*/snapshots/|https://app\.plusdocs\.com/.*/pages/edit/|https://app\.plusdocs\.com/.*/pages/share/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.plusdocs.com";
            yield return "plusdocs.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.plusdocs.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://podbean.com" />.
    /// </summary>
    public sealed partial class PodbeanMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.podbean\.com/e/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "podbean.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.podbean.com/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://uapod.univ-antilles.fr/" />.
    /// </summary>
    public sealed partial class PodUAntillesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://uapod\.univ-antilles\.fr/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "uapod.univ-antilles.fr";
            yield return "univ-antilles.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://uapod.univ-antilles.fr/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://umotion-test.univ-lemans.fr/" />.
    /// </summary>
    public sealed partial class PodULemansMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://umotion-test\.univ-lemans\.fr/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "umotion-test.univ-lemans.fr";
            yield return "univ-lemans.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://umotion-test.univ-lemans.fr/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://pod.univ-lille.fr/" />.
    /// </summary>
    public sealed partial class PodULilleMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://pod\.univ-lille\.fr/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "pod.univ-lille.fr";
            yield return "univ-lille.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://pod.univ-lille.fr/video/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://mediatheque.univ-paris1.fr/" />.
    /// </summary>
    public sealed partial class PodUParis1MetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://mediatheque\.univ-paris1\.fr/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "mediatheque.univ-paris1.fr";
            yield return "univ-paris1.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://mediatheque.univ-paris1.fr/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://pod.u-pec.fr/" />.
    /// </summary>
    public sealed partial class PodUPECMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://pod\.u-pec\.fr/video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "pod.u-pec.fr";
            yield return "u-pec.fr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://pod.u-pec.fr/oembed", request);
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
    /// Handles oEmbed request for <see href="https://present.do" />.
    /// </summary>
    public sealed partial class PresentMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://present\.do/decks/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "present.do";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://gateway.cobalt.run/present/decks/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://prezi.com/" />.
    /// </summary>
    public sealed partial class PreziMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://prezi\.com/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "prezi.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://prezi.com/v/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://qtpi.gg/" />.
    /// </summary>
    public sealed partial class QTpiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://qtpi\.gg/fashion/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "qtpi.gg";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://qtpi.gg/fashion/oembed", request);
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
    /// Handles oEmbed request for <see href="https://radiopublic.com" />.
    /// </summary>
    public sealed partial class RadiopublicMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://play\.radiopublic\.com/|https://radiopublic\.com/|https://www\.radiopublic\.com/|http://play\.radiopublic\.com/|http://radiopublic\.com/|http://www\.radiopublic\.com/|https://.*\.radiopublic\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.radiopublic.com";
            yield return "radiopublic.com";
            yield return "www.radiopublic.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://oembed.radiopublic.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://raindrop.io" />.
    /// </summary>
    public sealed partial class RaindropMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://raindrop\.io/|https://raindrop\.io/.*/|https://raindrop\.io/.*/.*/|https://raindrop\.io/.*/.*/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "raindrop.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://pub.raindrop.io/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.rcvis.com/" />.
    /// </summary>
    public sealed partial class RcvisMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.rcvis\.com/v/|https://www\.rcvis\.com/visualize=|https://www\.rcvis\.com/ve/|https://www\.rcvis\.com/visualizeEmbedded=)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.rcvis.com";
            yield return "rcvis.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://animatron.com/oembed", request);
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
            yield return "www.reddit.com";
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
    /// Handles oEmbed request for <see href="https://replit.com/" />.
    /// </summary>
    public sealed partial class ReplitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://repl\.it/@.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "repl.it";
            yield return "replit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://replit.com/data/oembed", request);
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
    /// Handles oEmbed request for <see href="https://roosterteeth.com" />.
    /// </summary>
    public sealed partial class RoosterteethMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://roosterteeth\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "roosterteeth.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://roosterteeth.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://runkit.com" />.
    /// </summary>
    public sealed partial class RunkitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^http://embed\.runkit\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "embed.runkit.com";
            yield return "runkit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.runkit.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://octopus.saooti.com" />.
    /// </summary>
    public sealed partial class SaootiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://octopus\.saooti\.com/main/pub/podcast/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "octopus.saooti.com";
            yield return "saooti.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://octopus.saooti.com/oembed", request);
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
    /// Handles oEmbed request for <see href="http://www.sendtonews.com/" />.
    /// </summary>
    public sealed partial class SendtonewsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://embed\.sendtonews\.com/oembed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "embed.sendtonews.com";
            yield return "sendtonews.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.sendtonews.com/services/oembed", request);
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
    /// Handles oEmbed request for <see href="https://simplecast.com" />.
    /// </summary>
    public sealed partial class SimplecastMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://simplecast\.com/s/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "simplecast.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://simplecast.com/oembed", request);
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
        private static readonly Regex _UriPattern = new Regex(@"^(http://sketchfab\.com/.*models/|https://sketchfab\.com/.*models/|https://sketchfab\.com/.*/folders/)");

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
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.slideshare\.net/.*/|http://www\.slideshare\.net/.*/|https://fr\.slideshare\.net/.*/|http://fr\.slideshare\.net/.*/|https://de\.slideshare\.net/.*/|http://de\.slideshare\.net/.*/|https://es\.slideshare\.net/.*/|http://es\.slideshare\.net/.*/|https://pt\.slideshare\.net/.*/|http://pt\.slideshare\.net/.*/)");

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
            => GetProviderUriCore("https://www.slideshare.net/api/oembed/2", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://smashnotes.com" />.
    /// </summary>
    public sealed partial class SmashnotesMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://smashnotes\.com/p/|https://smashnotes\.com/p/.*/e/|https://smashnotes\.com/p/.*/e/.*/s/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "smashnotes.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://smashnotes.com/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://smeme.com" />.
    /// </summary>
    public sealed partial class SmemeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://open\.smeme\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "open.smeme.com";
            yield return "smeme.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://open.smeme.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.smrthi.com" />.
    /// </summary>
    public sealed partial class SmrthiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.smrthi\.com/book/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.smrthi.com";
            yield return "smrthi.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.smrthi.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.smugmug.com/" />.
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
            => GetProviderUriCore("https://api.smugmug.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.socialexplorer.com/" />.
    /// </summary>
    public sealed partial class SocialexplorerMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.socialexplorer\.com/.*/explore|https://www\.socialexplorer\.com/.*/view|https://www\.socialexplorer\.com/.*/edit|https://www\.socialexplorer\.com/.*/embed)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.socialexplorer.com";
            yield return "socialexplorer.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.socialexplorer.com/services/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://odesli.co" />.
    /// </summary>
    public sealed partial class SonglinkMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://song\.link/|https://album\.link/|https://artist\.link/|https://playlist\.link/|https://pods\.link/|https://mylink\.page/|https://odesli\.co/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "song.link";
            yield return "album.link";
            yield return "artist.link";
            yield return "playlist.link";
            yield return "pods.link";
            yield return "mylink.page";
            yield return "odesli.co";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://song.link/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://soundcloud.com/" />.
    /// </summary>
    public sealed partial class SoundcloudMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://soundcloud\.com/|https://soundcloud\.com/|https://on\.soundcloud\.com/|https://soundcloud\.app\.goog\.gl/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "soundcloud.com";
            yield return "on.soundcloud.com";
            yield return "soundcloud.app.goog.gl";
            yield return "app.goog.gl";
            yield return "goog.gl";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://soundcloud.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://spotify.com/" />.
    /// </summary>
    public sealed partial class SpotifyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://open\.spotify\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "open.spotify.com";
            yield return "spotify.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://open.spotify.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://spotlightr.com" />.
    /// </summary>
    public sealed partial class SpotlightrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://spotlightr\.com");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "spotlightr.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.spotlightr.com/getOEmbed", request);
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
    /// Handles oEmbed request for <see href="https://sproutvideo.com" />.
    /// </summary>
    public sealed partial class SproutvideoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://sproutvideo\.com/videos/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "sproutvideo.com";
            yield return "vids.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("http://sproutvideo.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://purl.stanford.edu/" />.
    /// </summary>
    public sealed partial class StanfordDigitalRepositoryMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://purl\.stanford\.edu/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "purl.stanford.edu";
            yield return "stanford.edu";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://purl.stanford.edu/embed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://storymaps.arcgis.com" />.
    /// </summary>
    public sealed partial class StorymapsMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://storymaps\.arcgis\.com/stories/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "storymaps.arcgis.com";
            yield return "arcgis.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://storymaps.arcgis.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.streamio.com" />.
    /// </summary>
    public sealed partial class StreamioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://s3m\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "s3m.io";
            yield return "23m.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://streamio.com/api/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://subscribi.io/" />.
    /// </summary>
    public sealed partial class SubscribiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://subscribi\.io/api/oembed");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "subscribi.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://subscribi.io/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.sudomemo.net/" />.
    /// </summary>
    public sealed partial class SudomemoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.sudomemo\.net/watch/|http://www\.sudomemo\.net/watch/|https://flipnot\.es/|http://flipnot\.es/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.sudomemo.net";
            yield return "sudomemo.net";
            yield return "flipnot.es";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.sudomemo.net/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.sutori.com/" />.
    /// </summary>
    public sealed partial class SutoriMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.sutori\.com/story/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.sutori.com";
            yield return "sutori.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.sutori.com/api/oembed", request);
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
    /// Handles oEmbed request for <see href="https://sway.office.com" />.
    /// </summary>
    public sealed partial class SwayOfficeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://sway\.office\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "sway.office.com";
            yield return "office.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://sway.office.com/api/v1.0/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.synthesia.io/" />.
    /// </summary>
    public sealed partial class SynthesiaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://share\.synthesia\.io/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "share.synthesia.io";
            yield return "synthesia.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://69jr5v75rc.execute-api.eu-west-1.amazonaws.com/prod/v2/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.ted.com" />.
    /// </summary>
    public sealed partial class TedMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://ted\.com/talks/|https://ted\.com/talks/|https://www\.ted\.com/talks/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ted.com";
            yield return "www.ted.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://www.ted.com/services/v1/oembed", request);
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
    /// Handles oEmbed request for <see href="http://www.tiktok.com/" />.
    /// </summary>
    public sealed partial class TikTokMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.tiktok\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.tiktok.com";
            yield return "tiktok.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.tiktok.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.toornament.com/" />.
    /// </summary>
    public sealed partial class ToornamentMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://www\.toornament\.com/tournaments/.*/information|https://www\.toornament\.com/tournaments/.*/registration/|https://www\.toornament\.com/tournaments/.*/matches/schedule|https://www\.toornament\.com/tournaments/.*/stages/.*/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.toornament.com";
            yield return "toornament.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://widget.toornament.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://totango.com" />.
    /// </summary>
    public sealed partial class TotangoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app-test\.totango\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app-test.totango.com";
            yield return "totango.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app-test.totango.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://trinityaudio.ai" />.
    /// </summary>
    public sealed partial class TrinityaudioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://trinitymedia\.ai/player/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "trinitymedia.ai";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://trinitymedia.ai/player/trinity-oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.tumblr.com" />.
    /// </summary>
    public sealed partial class TumblrMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.tumblr\.com/post/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "tumblr.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.tumblr.com/oembed/1.0", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.tuxx.be/" />.
    /// </summary>
    public sealed partial class TuxxBeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.tuxx\.be/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.tuxx.be";
            yield return "tuxx.be";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.tuxx.be/services/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="http://tvcf.co.kr" />.
    /// </summary>
    public sealed partial class TvcfMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://play\.tvcf\.co\.kr/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.tvcf.co.kr";
            yield return "tvcf.co.kr";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://play.tvcf.co.kr/rest/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://twinmotion.unrealengine.com" />.
    /// </summary>
    public sealed partial class TwinmotionMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://twinmotion\.unrealengine\.com/presentation/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "twinmotion.unrealengine.com";
            yield return "unrealengine.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://twinmotion.unrealengine.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://typecast.ai" />.
    /// </summary>
    public sealed partial class TypecastMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://play\.typecast\.ai/s/|https://play\.typecast\.ai/e/|https://play\.typecast\.ai/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.typecast.ai";
            yield return "typecast.ai";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://play.typecast.ai/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://typlog.com" />.
    /// </summary>
    public sealed partial class TyplogMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://typlog\.com");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "typlog.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://typlog.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://map.cam.ac.uk" />.
    /// </summary>
    public sealed partial class UcamMapMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://map\.cam\.ac\.uk/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "map.cam.ac.uk";
            yield return "cam.ac.uk";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://map.cam.ac.uk/oembed/", request);
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
    /// Handles oEmbed request for <see href="https://www.ustudio.com" />.
    /// </summary>
    public sealed partial class UstudioMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.ustudio\.com/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "ustudio.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.ustudio.com/api/v2/oembed", request);
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
    /// Handles oEmbed request for <see href="https://videfit.com/" />.
    /// </summary>
    public sealed partial class VidefitMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://videfit\.com/videos/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "videfit.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://videfit.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vidmount.com/" />.
    /// </summary>
    public sealed partial class VidmountMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vidmount\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vidmount.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://vidmount.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vidyard.com" />.
    /// </summary>
    public sealed partial class VidyardMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(http://.*\.vidyard\.com/|https://.*\.vidyard\.com/|http://.*\.hubs\.vidyard\.com/|https://.*\.hubs\.vidyard\.com/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vidyard.com";
            yield return "hubs.vidyard.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.vidyard.com/dashboard/v1.1/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.viously.com" />.
    /// </summary>
    public sealed partial class ViouslyMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.viously\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.viously.com";
            yield return "viously.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.viously.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://vizydrop.com" />.
    /// </summary>
    public sealed partial class VizydropMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://vizydrop\.com/shared/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vizydrop.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://vizydrop.com/oembed", request);
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
    /// Handles oEmbed request for <see href="https://www.vlive.tv" />.
    /// </summary>
    public sealed partial class VliveMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://www\.vlive\.tv");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "www.vlive.tv";
            yield return "vlive.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.vlive.tv/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.vouchfor.com/" />.
    /// </summary>
    public sealed partial class VouchMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.vouchfor\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "vouchfor.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.vouchfor.com/v1/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://voxsnap.com/" />.
    /// </summary>
    public sealed partial class VoxsnapMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://article\.voxsnap\.com/.*/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "article.voxsnap.com";
            yield return "voxsnap.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://data.voxsnap.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://waltrack/net" />.
    /// </summary>
    public sealed partial class WaltrackMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://waltrack\.net/product/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "waltrack.net";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://waltrack.net/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://wave.video" />.
    /// </summary>
    public sealed partial class WavevideoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://watch\.wave\.video/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "watch.wave.video";
            yield return "wave.video";
            yield return "embed.wave.video";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://embed.wave.video/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.wecandeo.com/" />.
    /// </summary>
    public sealed partial class WecandeoMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://play\.wecandeo\.com/video/v/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "play.wecandeo.com";
            yield return "wecandeo.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://play.wecandeo.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.whimsical.com" />.
    /// </summary>
    public sealed partial class WhimsicalMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://whimsical\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "whimsical.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://whimsical.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://wistia.com/" />.
    /// </summary>
    public sealed partial class WistiaMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://wistia\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wistia.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriWithExtension("https://fast.wistia.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.wizer.me/" />.
    /// </summary>
    public sealed partial class WizerMeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.wizer\.me/learn/");

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
            => GetProviderUriWithExtension("https://app.wizer.me/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://wokwi.com" />.
    /// </summary>
    public sealed partial class WokwiMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://wokwi\.com/share/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wokwi.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://wokwi.com/api/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.wolframcloud.com" />.
    /// </summary>
    public sealed partial class WolframcloudMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.wolframcloud\.com/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wolframcloud.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.wolframcloud.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://wordpress.com/" />.
    /// </summary>
    public sealed partial class WordpressComMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://wordpress\.com/|http://wordpress\.com/|https://.*\.wordpress\.com/|http://.*\.wordpress\.com/|https://.*\..*\.wordpress\.com/|http://.*\..*\.wordpress\.com/|https://wp\.me/|http://wp\.me/)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "wordpress.com";
            yield return "wp.me";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("http://public-api.wordpress.com/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.youtube.com/" />.
    /// </summary>
    public sealed partial class YoutubeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://.*\.youtube\.com/watch|https://.*\.youtube\.com/v/|https://youtu\.be/|https://.*\.youtube\.com/playlist\?list=|https://youtube\.com/playlist\?list=|https://.*\.youtube\.com/shorts)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "youtube.com";
            yield return "youtu.be";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://www.youtube.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://zeplin.io" />.
    /// </summary>
    public sealed partial class ZeplinMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^(https://app\.zeplin\.io/project/.*/screen/|https://app\.zeplin\.io/project/.*/screen/.*/version/|https://app\.zeplin\.io/project/.*/styleguide/components\?coid=|https://app\.zeplin\.io/styleguide/.*/components\?coid=)");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.zeplin.io";
            yield return "zeplin.io";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.zeplin.io/embed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://app.zingsoft.com" />.
    /// </summary>
    public sealed partial class ZingsoftMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://app\.zingsoft\.com/embed/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "app.zingsoft.com";
            yield return "zingsoft.com";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://app.zingsoft.com/oembed", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://www.znipe.tv/" />.
    /// </summary>
    public sealed partial class ZnipeMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://.*\.znipe\.tv/");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "znipe.tv";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://api.znipe.tv/v3/oembed/", request);
    }

    /// <summary>
    /// Handles oEmbed request for <see href="https://zoomable.ca/" />.
    /// </summary>
    public sealed partial class ZoomableMetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https://srv2\.zoomable\.ca/viewer\.php");

        /// <inheritdoc />
        public override IEnumerable<string> GetSupportedHostNames()
        {
            yield return "srv2.zoomable.ca";
            yield return "zoomable.ca";
        }

        /// <inheritdoc />
        public override bool CanHandle(Uri uri)
            => _UriPattern.IsMatch(uri.ToString());

        /// <inheritdoc />
        protected override Uri GetProviderUriFor(ConsumerRequest request)
            => GetProviderUriCore("https://srv2.zoomable.ca/oembed", request);
    }

    partial class OEmbedProxyMetadataProvider
    {
        internal static IEnumerable<Type> CreateKnownHandlerTypes()
        {
            yield return typeof(TwentyThreeMetadataProvider);
            yield return typeof(AbraiaMetadataProvider);
            yield return typeof(AcastMetadataProvider);
            yield return typeof(ActblueMetadataProvider);
            yield return typeof(AdiloMetadataProvider);
            yield return typeof(AfreecatvMetadataProvider);
            yield return typeof(AltiumMetadataProvider);
            yield return typeof(AltrulabsMetadataProvider);
            yield return typeof(AmchartsLiveEditorMetadataProvider);
            yield return typeof(AmtrakerMetadataProvider);
            yield return typeof(AnimatronMetadataProvider);
            yield return typeof(AnimotoMetadataProvider);
            yield return typeof(AnniemusicMetadataProvider);
            yield return typeof(ArchivosMetadataProvider);
            yield return typeof(AudioboomMetadataProvider);
            yield return typeof(AudioclipMetadataProvider);
            yield return typeof(AudiomackMetadataProvider);
            yield return typeof(AudiomeansMetadataProvider);
            yield return typeof(AvocodeMetadataProvider);
            yield return typeof(BacktracksMetadataProvider);
            yield return typeof(BeamsMetadataProvider);
            yield return typeof(BeautifulMetadataProvider);
            yield return typeof(BlackfireIoMetadataProvider);
            yield return typeof(BlogcastMetadataProvider);
            yield return typeof(BookingmoodMetadataProvider);
            yield return typeof(BoxofficebuzMetadataProvider);
            yield return typeof(BriovrMetadataProvider);
            yield return typeof(BumperMetadataProvider);
            yield return typeof(ButtondownMetadataProvider);
            yield return typeof(ByzartMetadataProvider);
            yield return typeof(CacooMetadataProvider);
            yield return typeof(CatboatMetadataProvider);
            yield return typeof(CerosMetadataProvider);
            yield return typeof(ChainflixMetadataProvider);
            yield return typeof(ChartblocksMetadataProvider);
            yield return typeof(ChirbitComMetadataProvider);
            yield return typeof(ChrocoMetadataProvider);
            yield return typeof(CircuitlabMetadataProvider);
            yield return typeof(CliplandMetadataProvider);
            yield return typeof(ClypMetadataProvider);
            yield return typeof(CocoCorpMetadataProvider);
            yield return typeof(CodehsMetadataProvider);
            yield return typeof(CodepenMetadataProvider);
            yield return typeof(CodepointsMetadataProvider);
            yield return typeof(CodesandboxMetadataProvider);
            yield return typeof(CollegehumorMetadataProvider);
            yield return typeof(CommafulMetadataProvider);
            yield return typeof(CoubMetadataProvider);
            yield return typeof(CrowdRankingMetadataProvider);
            yield return typeof(CrumbsMetadataProvider);
            yield return typeof(CueupMetadataProvider);
            yield return typeof(CuratedMetadataProvider);
            yield return typeof(CustomerdbMetadataProvider);
            yield return typeof(DadanMetadataProvider);
            yield return typeof(DailymotionMetadataProvider);
            yield return typeof(DalexniMetadataProvider);
            yield return typeof(DatawrapperMetadataProvider);
            yield return typeof(DeseretnewsMetadataProvider);
            yield return typeof(DeviantartComMetadataProvider);
            yield return typeof(DigitekaMetadataProvider);
            yield return typeof(DocdroidMetadataProvider);
            yield return typeof(DocswellMetadataProvider);
            yield return typeof(DotsubMetadataProvider);
            yield return typeof(DreambrokerMetadataProvider);
            yield return typeof(DtubeMetadataProvider);
            yield return typeof(EdumediaSciencesComMetadataProvider);
            yield return typeof(EgliseinfoMetadataProvider);
            yield return typeof(EmbederyMetadataProvider);
            yield return typeof(EnystreMusicMetadataProvider);
            yield return typeof(EthfiddleMetadataProvider);
            yield return typeof(EventliveMetadataProvider);
            yield return typeof(EvervizMetadataProvider);
            yield return typeof(ExcoMetadataProvider);
            yield return typeof(EyrieioMetadataProvider);
            yield return typeof(FacebookMetadataProvider);
            yield return typeof(FaderMetadataProvider);
            yield return typeof(FaithlifetvMetadataProvider);
            yield return typeof(FireworktvMetadataProvider);
            yield return typeof(FiteMetadataProvider);
            yield return typeof(FlatMetadataProvider);
            yield return typeof(FlickrMetadataProvider);
            yield return typeof(FlourishMetadataProvider);
            yield return typeof(FoxSportsAustraliaMetadataProvider);
            yield return typeof(FramebuzzMetadataProvider);
            yield return typeof(FramerMetadataProvider);
            yield return typeof(GeographMetadataProvider);
            yield return typeof(GetshowMetadataProvider);
            yield return typeof(GettyImagesMetadataProvider);
            yield return typeof(GfycatMetadataProvider);
            yield return typeof(GifnoteMetadataProvider);
            yield return typeof(GIPHYMetadataProvider);
            yield return typeof(GloriatvMetadataProvider);
            yield return typeof(GmetriMetadataProvider);
            yield return typeof(GongMetadataProvider);
            yield return typeof(GrainMetadataProvider);
            yield return typeof(GtchannelMetadataProvider);
            yield return typeof(HASHMetadataProvider);
            yield return typeof(HearthisMetadataProvider);
            yield return typeof(HeyzineMetadataProvider);
            yield return typeof(HihahoMetadataProvider);
            yield return typeof(HippovideoMetadataProvider);
            yield return typeof(HomeyMetadataProvider);
            yield return typeof(HuffdufferMetadataProvider);
            yield return typeof(HuluMetadataProvider);
            yield return typeof(IdomooMetadataProvider);
            yield return typeof(IfixitMetadataProvider);
            yield return typeof(IftttMetadataProvider);
            yield return typeof(IheartradioMetadataProvider);
            yield return typeof(ImenuproMetadataProvider);
            yield return typeof(IncredibleMetadataProvider);
            yield return typeof(IndacoMetadataProvider);
            yield return typeof(InfogramMetadataProvider);
            yield return typeof(InfoveaveMetadataProvider);
            yield return typeof(InjurymapMetadataProvider);
            yield return typeof(InoreaderMetadataProvider);
            yield return typeof(InphoodMetadataProvider);
            yield return typeof(InstagramMetadataProvider);
            yield return typeof(InsticatorMetadataProvider);
            yield return typeof(IssuuMetadataProvider);
            yield return typeof(JovianMetadataProvider);
            yield return typeof(KakaotvMetadataProvider);
            yield return typeof(KickstarterMetadataProvider);
            yield return typeof(KidojuMetadataProvider);
            yield return typeof(KirimemailMetadataProvider);
            yield return typeof(KitMetadataProvider);
            yield return typeof(KitchenbowlMetadataProvider);
            yield return typeof(KmdrMetadataProvider);
            yield return typeof(KnackiMetadataProvider);
            yield return typeof(KnowledgepadMetadataProvider);
            yield return typeof(KooappMetadataProvider);
            yield return typeof(KurozoraMetadataProvider);
            yield return typeof(LearningappsOrgMetadataProvider);
            yield return typeof(LineplaceMetadataProvider);
            yield return typeof(LivestreamMetadataProvider);
            yield return typeof(LottiefilesMetadataProvider);
            yield return typeof(LudusMetadataProvider);
            yield return typeof(LumiereMetadataProvider);
            yield return typeof(MathembedMetadataProvider);
            yield return typeof(MatterportMetadataProvider);
            yield return typeof(MediastreamMetadataProvider);
            yield return typeof(MedienarchivZhdkMetadataProvider);
            yield return typeof(MemeMetadataProvider);
            yield return typeof(MermaidInkMetadataProvider);
            yield return typeof(MicrosoftStreamMetadataProvider);
            yield return typeof(MinervaMetadataProvider);
            yield return typeof(MinesweeperTodayMetadataProvider);
            yield return typeof(MiroMetadataProvider);
            yield return typeof(MixcloudMetadataProvider);
            yield return typeof(MixpanelMetadataProvider);
            yield return typeof(MobyPictureMetadataProvider);
            yield return typeof(MusicboxmaniacsComMetadataProvider);
            yield return typeof(MybeweegMetadataProvider);
            yield return typeof(NamcheyMetadataProvider);
            yield return typeof(NasjonalbiblioteketMetadataProvider);
            yield return typeof(NaturalatlasMetadataProvider);
            yield return typeof(NdlaMetadataProvider);
            yield return typeof(NfbCaMetadataProvider);
            yield return typeof(NopasteMetadataProvider);
            yield return typeof(ObservableMetadataProvider);
            yield return typeof(OddsMetadataProvider);
            yield return typeof(OdyseeMetadataProvider);
            yield return typeof(OfficialFmMetadataProvider);
            yield return typeof(OmniscopeMeMetadataProvider);
            yield return typeof(OmnystudioMetadataProvider);
            yield return typeof(OrbitvuMetadataProvider);
            yield return typeof(OutplayedTvMetadataProvider);
            yield return typeof(OverflowIoMetadataProvider);
            yield return typeof(OzMetadataProvider);
            yield return typeof(PadletMetadataProvider);
            yield return typeof(PandavideoMetadataProvider);
            yield return typeof(PasteryMetadataProvider);
            yield return typeof(PicturelfyMetadataProvider);
            yield return typeof(PikassoMetadataProvider);
            yield return typeof(PingvpMetadataProvider);
            yield return typeof(PinpollMetadataProvider);
            yield return typeof(PinterestMetadataProvider);
            yield return typeof(PitchhubMetadataProvider);
            yield return typeof(PixdorMetadataProvider);
            yield return typeof(PlusdocsMetadataProvider);
            yield return typeof(PodbeanMetadataProvider);
            yield return typeof(PodUAntillesMetadataProvider);
            yield return typeof(PodULemansMetadataProvider);
            yield return typeof(PodULilleMetadataProvider);
            yield return typeof(PodUParis1MetadataProvider);
            yield return typeof(PodUPECMetadataProvider);
            yield return typeof(PollDaddyMetadataProvider);
            yield return typeof(PortfoliumMetadataProvider);
            yield return typeof(PresentMetadataProvider);
            yield return typeof(PreziMetadataProvider);
            yield return typeof(QTpiMetadataProvider);
            yield return typeof(QuizBizMetadataProvider);
            yield return typeof(RadiopublicMetadataProvider);
            yield return typeof(RaindropMetadataProvider);
            yield return typeof(RcvisMetadataProvider);
            yield return typeof(RedditMetadataProvider);
            yield return typeof(ReleasewireMetadataProvider);
            yield return typeof(ReplitMetadataProvider);
            yield return typeof(ReverbnationMetadataProvider);
            yield return typeof(RoomshareMetadataProvider);
            yield return typeof(RoosterteethMetadataProvider);
            yield return typeof(RumbleMetadataProvider);
            yield return typeof(RunkitMetadataProvider);
            yield return typeof(SaootiMetadataProvider);
            yield return typeof(SapoVideosMetadataProvider);
            yield return typeof(Screen9MetadataProvider);
            yield return typeof(ScreencastComMetadataProvider);
            yield return typeof(ScreenrMetadataProvider);
            yield return typeof(ScribblemapsMetadataProvider);
            yield return typeof(ScribdMetadataProvider);
            yield return typeof(SendtonewsMetadataProvider);
            yield return typeof(ShortnoteMetadataProvider);
            yield return typeof(ShoudioMetadataProvider);
            yield return typeof(ShowTheWayMetadataProvider);
            yield return typeof(SimplecastMetadataProvider);
            yield return typeof(SizzleMetadataProvider);
            yield return typeof(SketchfabMetadataProvider);
            yield return typeof(SlideshareMetadataProvider);
            yield return typeof(SmashnotesMetadataProvider);
            yield return typeof(SmemeMetadataProvider);
            yield return typeof(SmrthiMetadataProvider);
            yield return typeof(SmugmugMetadataProvider);
            yield return typeof(SocialexplorerMetadataProvider);
            yield return typeof(SonglinkMetadataProvider);
            yield return typeof(SoundcloudMetadataProvider);
            yield return typeof(SpeakerdeckMetadataProvider);
            yield return typeof(SpotifyMetadataProvider);
            yield return typeof(SpotlightrMetadataProvider);
            yield return typeof(SpreakerMetadataProvider);
            yield return typeof(SproutvideoMetadataProvider);
            yield return typeof(StanfordDigitalRepositoryMetadataProvider);
            yield return typeof(StorymapsMetadataProvider);
            yield return typeof(StreamableMetadataProvider);
            yield return typeof(StreamioMetadataProvider);
            yield return typeof(SubscribiMetadataProvider);
            yield return typeof(SudomemoMetadataProvider);
            yield return typeof(SutoriMetadataProvider);
            yield return typeof(SwayMetadataProvider);
            yield return typeof(SwayOfficeMetadataProvider);
            yield return typeof(SynthesiaMetadataProvider);
            yield return typeof(TedMetadataProvider);
            yield return typeof(TheySaidSoMetadataProvider);
            yield return typeof(TheNewYorkTimesMetadataProvider);
            yield return typeof(TickcounterMetadataProvider);
            yield return typeof(TikTokMetadataProvider);
            yield return typeof(ToornamentMetadataProvider);
            yield return typeof(TopyMetadataProvider);
            yield return typeof(TotangoMetadataProvider);
            yield return typeof(TrinityaudioMetadataProvider);
            yield return typeof(TumblrMetadataProvider);
            yield return typeof(TuxxBeMetadataProvider);
            yield return typeof(TvcfMetadataProvider);
            yield return typeof(TwinmotionMetadataProvider);
            yield return typeof(TypecastMetadataProvider);
            yield return typeof(TyplogMetadataProvider);
            yield return typeof(UcamMapMetadataProvider);
            yield return typeof(UstreamMetadataProvider);
            yield return typeof(UstudioMetadataProvider);
            yield return typeof(VeerMetadataProvider);
            yield return typeof(VevoMetadataProvider);
            yield return typeof(VidefitMetadataProvider);
            yield return typeof(VidmountMetadataProvider);
            yield return typeof(VidyardMetadataProvider);
            yield return typeof(VimeoMetadataProvider);
            yield return typeof(ViouslyMetadataProvider);
            yield return typeof(VizydropMetadataProvider);
            yield return typeof(VlipsyMetadataProvider);
            yield return typeof(VliveMetadataProvider);
            yield return typeof(VouchMetadataProvider);
            yield return typeof(VoxsnapMetadataProvider);
            yield return typeof(WaltrackMetadataProvider);
            yield return typeof(WavevideoMetadataProvider);
            yield return typeof(WecandeoMetadataProvider);
            yield return typeof(WhimsicalMetadataProvider);
            yield return typeof(WistiaMetadataProvider);
            yield return typeof(WizerMeMetadataProvider);
            yield return typeof(WokwiMetadataProvider);
            yield return typeof(WolframcloudMetadataProvider);
            yield return typeof(WordpressComMetadataProvider);
            yield return typeof(YoutubeMetadataProvider);
            yield return typeof(ZeplinMetadataProvider);
            yield return typeof(ZingsoftMetadataProvider);
            yield return typeof(ZnipeMetadataProvider);
            yield return typeof(ZoomableMetadataProvider);
        }
    }
}
