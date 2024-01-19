using TextProcess.Wpf.Core.Contracts.Models;

namespace TextProcess.Wpf.Core.Models.Request
{
    /// <summary>
    /// Represents a class implementing the <see cref="IText"/> interface.
    /// </summary>
    internal class TextRequest : IText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextRequest"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text for the request.</param>
        public TextRequest(string text)
        {
            Text = text;
        }

        /// <inheritdoc/>
        public string Text { get; set; } = string.Empty;
    }
}
