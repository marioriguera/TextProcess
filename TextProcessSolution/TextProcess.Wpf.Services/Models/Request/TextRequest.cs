using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Request
{
    /// <summary>
    /// Represents a class implementing the <see cref="IText"/> interface.
    /// </summary>
    internal class TextRequest : IText
    {
        /// <inheritdoc/>
        public string Text { get; set; } = string.Empty;
    }
}
