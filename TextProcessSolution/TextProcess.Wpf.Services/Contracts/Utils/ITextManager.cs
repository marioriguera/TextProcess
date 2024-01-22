namespace TextProcess.Wpf.Core.Contracts.Utils
{
    /// <summary>
    /// Defines the contract for a manager responsible for text manipulation.
    /// </summary>
    internal interface ITextManager
    {
        /// <summary>
        /// Removes line breaks from the specified input text.
        /// </summary>
        /// <param name="input">The text from which to remove line breaks.</param>
        /// <returns>The modified text without line breaks.</returns>
        string RemoveLineBreaks(string input);
    }
}
