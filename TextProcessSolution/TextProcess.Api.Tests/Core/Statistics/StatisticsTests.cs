using Microsoft.Extensions.DependencyInjection;
using TextProcess.Api.Core.Contracts.Services;
using TextProcess.Api.Tests.Core.Configurations;

namespace TextProcess.Api.Tests.Core.Statistics
{
    /// <summary>
    /// Represents unit tests for the ITextAnalyzer to ensure accurate text statistics.
    /// </summary>
    public class StatisticsTests
    {
        private readonly ITextAnalyzerService _textAnalyzer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsTests"/> class.
        /// </summary>
        public StatisticsTests()
        {
            // Obtain the ITextAnalyzerService from the service collection
            _textAnalyzer = ConfigurationServiceTests.Current.TestHost.Services.GetRequiredService<ITextAnalyzerService>();
        }

        /// <summary>
        /// Tests the Statistics method with three words, two white spaces, and zero hyphens.
        /// </summary>
        [Theory]
        [InlineData("Casa Piedra Cuatro")]
        [InlineData("Perro Vecino Adios")]
        [InlineData("Cocina Comida Anterior")]
        public void Statistics_Three_Words_Two_White_Spaces_Cero_Hyphen(string text)
        {
            // Act
            var result = _textAnalyzer.AnalyzeText(text);

            // Assert
            Assert.Equal(3, (int)result.WordCount);
            Assert.Equal(2, (int)result.SpaceCount);
            Assert.Equal(0, (int)result.HyphenCount);
        }

        /// <summary>
        /// Tests the Statistics method with one word, zero white spaces, and one hyphen.
        /// </summary>
        [Theory]
        [InlineData("Casa-")]
        [InlineData("-Pedro")]
        [InlineData("Menos-")]
        [InlineData("Palabra-")]
        public void Statistics_One_Word_Cero_White_Space_One_Hyphen(string text)
        {
            // Act
            var result = _textAnalyzer.AnalyzeText(text);

            // Assert
            Assert.Equal(1, (int)result.WordCount);
            Assert.Equal(0, (int)result.SpaceCount);
            Assert.Equal(1, (int)result.HyphenCount);
        }

        /// <summary>
        /// Tests the Statistics method with zero words, three white spaces, and two hyphens.
        /// </summary>
        [Theory]
        [InlineData(" - - ")]
        [InlineData("--   ")]
        [InlineData("   --")]
        public void Statistics_Cero_Word_Three_White_Space_Two_Hyphen(string text)
        {
            // Act
            var result = _textAnalyzer.AnalyzeText(text);

            // Assert
            Assert.Equal(0, (int)result.WordCount);
            Assert.Equal(3, (int)result.SpaceCount);
            Assert.Equal(2, (int)result.HyphenCount);
        }

        /// <summary>
        /// Tests the Statistics method with two words, zero white spaces, and one hyphen.
        /// </summary>
        [Theory]
        [InlineData("Palabra-Menos")]
        [InlineData("Planeta-Casa")]
        [InlineData("Tormenta-Sol")]
        public void Statistics_Two_Word_Cero_White_Space_One_Hyphen(string text)
        {
            // Act
            var result = _textAnalyzer.AnalyzeText(text);

            // Assert
            Assert.Equal(2, (int)result.WordCount);
            Assert.Equal(0, (int)result.SpaceCount);
            Assert.Equal(1, (int)result.HyphenCount);
        }

        /// <summary>
        /// Tests the Statistics method with null or empty text, expecting zero for all counts.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Statistics_Cero_Word_Cero_White_Space_Cero_Hyphen(string text)
        {
            // Act
            var result = _textAnalyzer.AnalyzeText(text);

            // Assert
            Assert.Equal(0, (int)result.WordCount);
            Assert.Equal(0, (int)result.SpaceCount);
            Assert.Equal(0, (int)result.HyphenCount);
        }
    }
}
