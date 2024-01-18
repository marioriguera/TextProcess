using System.Text;
using TextProcess.Api.Configuration;
using TextProcess.Api.Contracts;

namespace TextProcess.Api.Models.Request
{
    /// <summary>
    /// Represents a class for a request to gather statistics on ordered text.
    /// </summary>
    public class StatisticsOrderRequest : IValidRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsOrderRequest"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text for which statistics will be gathered. Must not be <c>null</c> or empty.</param>
        public StatisticsOrderRequest(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Gets the text for which statistics will be gathered.
        /// </summary>
        public string Text { get; private set; }

        /// <inheritdoc/>
        public bool IsValid()
        {
            bool isValid = !string.IsNullOrEmpty(Text);
            if (!isValid) ConfigurationService.Current.Logger.Warn($"A {nameof(StatisticsOrderRequest)} class is invalid. {ToString()}");
            return isValid;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{nameof(Text)} = {Text ?? string.Empty} ");

            return builder.ToString();
        }
    }
}
