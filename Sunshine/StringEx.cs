using System.Text.RegularExpressions;

namespace Sunshine
{
    // From http://stackoverflow.com/questions/3103730/is-there-a-elegant-way-to-parse-a-word-and-add-spaces-before-capital-letters
    public static class StringEx
    {
        private static readonly Regex r = new Regex(
           @"  (?<=[A-Z])(?=[A-Z][a-z])    # UC before me, UC lc after me
            |  (?<=[^A-Z])(?=[A-Z])        # Not UC before me, UC after me
            |  (?<=[A-Za-z])(?=[^A-Za-z])  # Letter before me, non letter after me
            ", RegexOptions.IgnorePatternWhitespace);

        public static string ToWords(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            string result = string.Empty;
            foreach (string part in r.Split(s))
                result += part + " ";

            return result.TrimEnd(' ');
        }
    }
}
