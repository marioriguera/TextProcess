using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcess.Api.Core.Contracts.Models
{
    /// <summary>
    /// Represents an interface for collecting statistics on text content.
    /// </summary>
    public interface ITextStatistics
    {
        /// <summary>
        /// Gets or sets the count of words in the text.
        /// </summary>
        ulong WordCount { get; set; }

        /// <summary>
        /// Gets or sets the count of spaces in the text.
        /// </summary>
        ulong SpaceCount { get; set; }

        /// <summary>
        /// Gets or sets the count of hyphens in the text.
        /// </summary>
        ulong HyphenCount { get; set; }
    }
}
