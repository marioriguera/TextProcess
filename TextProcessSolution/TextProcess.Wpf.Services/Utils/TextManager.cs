using System.Text.RegularExpressions;
using TextProcess.Wpf.Core.Contracts.Utils;

namespace TextProcess.Wpf.Core.Utils
{
    /// <summary>
    /// A class responsible for text manipulation.
    /// </summary>
    internal class TextManager : ITextManager
    {
        /// <inheritdoc/>
        public string RemoveLineBreaks(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Replace one or more consecutive line breaks with a single space
            return Regex.Replace(input, @"\n+", " ");
        }
    }
}
