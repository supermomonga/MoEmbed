using System.Linq;

namespace MoEmbed.Models
{
    internal static class StringHelper
    {
        public static string ToSnakeCase(this string s)
            => string.Concat(s.Select(c => char.IsUpper(c) ? "_" + char.ToLower(c) : new string(c, 1))).TrimStart('_');
    }
}