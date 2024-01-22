using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Utils;

namespace TextProcess.Wpf.Tests.Utils
{
    /// <summary>
    /// Represents a set of unit tests for the <see cref="TextManager"/> class.
    /// </summary>
    public class TextManagerTests
    {
        private readonly ITextManager _textManager = new TextManager();

        /// <summary>
        /// Tests the RemoveLineBreaks method with an empty string.
        /// </summary>
        [Fact]
        public void RemoveLineBreaks_EmptyString()
        {
            Assert.Empty(_textManager.RemoveLineBreaks(string.Empty));
        }

        /// <summary>
        /// Tests the RemoveLineBreaks method with a null string.
        /// </summary>
        [Fact]
        public void RemoveLineBreaks_NullString()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Null(_textManager.RemoveLineBreaks(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        /// <summary>
        /// Tests the RemoveLineBreaks method without line breaks in the input.
        /// </summary>
        [Fact]
        public void RemoveLineBreaks_WithoutBreaks()
        {
            Assert.Equal("--Donec id interdum velit. Etiam rutrum.--", _textManager.RemoveLineBreaks("--Donec id interdum velit. Etiam rutrum.--"));
        }

        /// <summary>
        /// Tests the RemoveLineBreaks method with line breaks in the input.
        /// </summary>
        [Fact]
        public void RemoveLineBreaks_WithBreaks()
        {
            Assert.Equal("--Donec id interdum  velit. Etiam rutrum.--", _textManager.RemoveLineBreaks("--Donec id interdum\n\n velit. Etiam rutrum.--"));
        }
    }
}