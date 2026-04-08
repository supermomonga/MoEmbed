using System;
using System.Collections.Generic;
using System.Linq;

namespace MoEmbed.CodeGeneration;

public class ProviderHostEntry
{
    public string ProviderName { get; set; }
    public List<string> CandidateHostNames { get; set; }
}

public static class HostNameResolver
{
    /// <summary>
    /// Resolves host name conflicts across providers.
    /// When multiple providers claim the same host name, it is assigned to
    /// the provider whose name is most similar to the host name.
    /// </summary>
    /// <returns>A dictionary mapping each provider name to its resolved (deduplicated) host names.</returns>
    public static Dictionary<string, List<string>> Resolve(IEnumerable<ProviderHostEntry> entries)
    {
        var entryList = entries.ToList();

        // Collect all host names and their claimant provider names
        var hostToProviders = new Dictionary<string, List<string>>();
        foreach (var entry in entryList)
        {
            foreach (var hn in entry.CandidateHostNames)
            {
                if (!hostToProviders.ContainsKey(hn))
                    hostToProviders[hn] = new List<string>();
                hostToProviders[hn].Add(entry.ProviderName);
            }
        }

        // For conflicting hosts, assign to the provider with the highest similarity
        var hostOwner = new Dictionary<string, string>();
        foreach (var (host, claimants) in hostToProviders)
        {
            if (claimants.Count == 1)
            {
                hostOwner[host] = claimants[0];
            }
            else
            {
                var winner = claimants
                    .OrderByDescending(name => HostNameSimilarity(name, host))
                    .ThenBy(name => name) // stable tie-break: alphabetical
                    .First();
                hostOwner[host] = winner;
            }
        }

        // Build resolved host name lists per provider
        var result = new Dictionary<string, List<string>>();
        foreach (var entry in entryList)
        {
            result[entry.ProviderName] = entry.CandidateHostNames
                .Where(hn => hostOwner[hn] == entry.ProviderName)
                .ToList();
        }
        return result;
    }

    /// <summary>
    /// Computes similarity between a provider name and a host name
    /// using the longest common substring after normalization.
    /// </summary>
    public static int HostNameSimilarity(string providerName, string hostName)
    {
        var hostNormalized = hostName.Replace(".", "").Replace("-", "").ToLowerInvariant();
        var provNormalized = providerName.Replace("_", "").Replace("-", "").ToLowerInvariant();

        return LongestCommonSubstringLength(provNormalized, hostNormalized);
    }

    /// <summary>
    /// Returns the length of the longest common substring between two strings.
    /// </summary>
    public static int LongestCommonSubstringLength(string a, string b)
    {
        if (a.Length == 0 || b.Length == 0) return 0;

        var maxLen = 0;
        var prev = new int[b.Length + 1];
        var curr = new int[b.Length + 1];

        for (var i = 1; i <= a.Length; i++)
        {
            for (var j = 1; j <= b.Length; j++)
            {
                if (a[i - 1] == b[j - 1])
                {
                    curr[j] = prev[j - 1] + 1;
                    if (curr[j] > maxLen) maxLen = curr[j];
                }
                else
                {
                    curr[j] = 0;
                }
            }
            (prev, curr) = (curr, prev);
            Array.Clear(curr, 0, curr.Length);
        }
        return maxLen;
    }
}
