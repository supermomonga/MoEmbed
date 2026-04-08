namespace MoEmbed.CodeGeneration;

public class LongestCommonSubstringLengthTest
{
    [Test]
    [Arguments("abc", "abc", 3)]
    [Arguments("abc", "def", 0)]
    [Arguments("abcdef", "xcdey", 3)] // "cde"
    [Arguments("", "abc", 0)]
    [Arguments("abc", "", 0)]
    [Arguments("afreecatv", "vafreeca", 7)] // "afreeca"
    [Arguments("sooplive", "vafreeca", 1)] // "a"
    public async Task ReturnsExpectedLength(string a, string b, int expected)
    {
        var result = HostNameResolver.LongestCommonSubstringLength(a, b);
        await Assert.That(result).IsEqualTo(expected);
    }
}

public class HostNameSimilarityTest
{
    [Test]
    [Arguments("afreecatv", "v.afree.ca", 7)] // normalized: "afreecatv" vs "vafreeca" -> "afreeca" (7)
    [Arguments("sooplive", "v.afree.ca", 1)]   // normalized: "sooplive" vs "vafreeca" -> "a" (1)
    [Arguments("sooplive", "vod.sooplive.com", 8)] // normalized: "sooplive" vs "vodsooplivecom" -> "sooplive" (8)
    [Arguments("afreecatv", "vod.afreecatv.com", 9)] // normalized: "afreecatv" vs "vodafreecatvcom" -> "afreecatv" (9)
    [Arguments("my-service", "my-service.example.com", 9)] // hyphens stripped from both
    public async Task ReturnsExpectedSimilarity(string providerName, string hostName, int expected)
    {
        var result = HostNameResolver.HostNameSimilarity(providerName, hostName);
        await Assert.That(result).IsEqualTo(expected);
    }
}

public class HostNameResolverTest
{
    [Test]
    public async Task NoConflict_AllHostNamesPreserved()
    {
        var entries = new[]
        {
            new ProviderHostEntry { ProviderName = "youtube", CandidateHostNames = ["youtube.com", "youtu.be"] },
            new ProviderHostEntry { ProviderName = "vimeo", CandidateHostNames = ["vimeo.com"] }
        };

        var result = HostNameResolver.Resolve(entries);

        await Assert.That(result["youtube"]).IsEquivalentTo(new[] { "youtube.com", "youtu.be" });
        await Assert.That(result["vimeo"]).IsEquivalentTo(new[] { "vimeo.com" });
    }

    [Test]
    public async Task ConflictingHost_AssignedToMoreSimilarProvider()
    {
        // Real-world case: afreecatv and sooplive both claim v.afree.ca
        var entries = new[]
        {
            new ProviderHostEntry
            {
                ProviderName = "afreecatv",
                CandidateHostNames = ["vod.afreecatv.com", "afreecatv.com", "v.afree.ca", "afree.ca", "play.afreecatv.com"]
            },
            new ProviderHostEntry
            {
                ProviderName = "sooplive",
                CandidateHostNames = ["vod.sooplive.com", "sooplive.com", "v.afree.ca", "afree.ca", "play.sooplive.com"]
            }
        };

        var result = HostNameResolver.Resolve(entries);

        // v.afree.ca and afree.ca should go to afreecatv (higher similarity)
        await Assert.That(result["afreecatv"]).Contains("v.afree.ca");
        await Assert.That(result["afreecatv"]).Contains("afree.ca");
        await Assert.That(result["sooplive"]).DoesNotContain("v.afree.ca");
        await Assert.That(result["sooplive"]).DoesNotContain("afree.ca");

        // Each provider's own hosts are unaffected
        await Assert.That(result["afreecatv"]).Contains("vod.afreecatv.com");
        await Assert.That(result["sooplive"]).Contains("vod.sooplive.com");
        await Assert.That(result["sooplive"]).Contains("play.sooplive.com");
    }

    [Test]
    public async Task ConflictingHost_TieBreaksAlphabetically()
    {
        // Both providers have equal similarity to the shared host
        var entries = new[]
        {
            new ProviderHostEntry
            {
                ProviderName = "bravo",
                CandidateHostNames = ["shared.example.com"]
            },
            new ProviderHostEntry
            {
                ProviderName = "alpha",
                CandidateHostNames = ["shared.example.com"]
            }
        };

        var result = HostNameResolver.Resolve(entries);

        // Equal similarity -> alphabetical tie-break -> "alpha" wins
        await Assert.That(result["alpha"]).Contains("shared.example.com");
        await Assert.That(result["bravo"]).DoesNotContain("shared.example.com");
    }

    [Test]
    public async Task ThreeProviders_ConflictResolvedCorrectly()
    {
        var entries = new[]
        {
            new ProviderHostEntry
            {
                ProviderName = "foobar",
                CandidateHostNames = ["foobar.com", "api.foo.com"]
            },
            new ProviderHostEntry
            {
                ProviderName = "foobaz",
                CandidateHostNames = ["foobaz.net", "api.foo.com"]
            },
            new ProviderHostEntry
            {
                ProviderName = "qux",
                CandidateHostNames = ["qux.io", "api.foo.com"]
            }
        };

        var result = HostNameResolver.Resolve(entries);

        // "api.foo.com" -> normalized "apifoocom"
        // "foobar" LCS with "apifoocom" = "foo" (3)
        // "foobaz" LCS with "apifoocom" = "foo" (3)
        // "qux" LCS with "apifoocom" = 0
        // Tie between foobar and foobaz -> alphabetical -> "foobar" wins
        await Assert.That(result["foobar"]).Contains("api.foo.com");
        await Assert.That(result["foobaz"]).DoesNotContain("api.foo.com");
        await Assert.That(result["qux"]).DoesNotContain("api.foo.com");

        // Unique hosts unaffected
        await Assert.That(result["foobar"]).Contains("foobar.com");
        await Assert.That(result["foobaz"]).Contains("foobaz.net");
        await Assert.That(result["qux"]).Contains("qux.io");
    }

    [Test]
    public async Task EmptyCandidates_ReturnsEmptyList()
    {
        var entries = new[]
        {
            new ProviderHostEntry { ProviderName = "empty", CandidateHostNames = [] }
        };

        var result = HostNameResolver.Resolve(entries);

        await Assert.That(result["empty"]).IsEmpty();
    }
}
