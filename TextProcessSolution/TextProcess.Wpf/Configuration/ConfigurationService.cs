using System.ComponentModel;
using System.Windows;
using Microsoft.Extensions.Hosting;

namespace TextProcess.Wpf.Configuration
{
    /// <summary>
    /// Manages configuration service values.
    /// </summary>
    public sealed class ConfigurationService
    {
        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <remarks>
        /// Explicit static constructor to tell C# compiler not to mark type as before field initialization.
        /// </remarks>
        static ConfigurationService()
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ConfigurationService"/> class from being created.
        /// </summary>
        private ConfigurationService()
        {
        }
        #endregion

        #region Core Properties

        /// <summary>
        /// Gets current service configuration.
        /// </summary>
        public static ConfigurationService Current { get; } = new ConfigurationService();

        /// <summary>
        /// Gets a value indicating whether application is in design mode or not.
        /// </summary>
        public static bool IsInDesignMode { get => DesignerProperties.GetIsInDesignMode(new DependencyObject()); }

        /// <summary>
        /// Gets or sets manage host.
        /// </summary>
        public IHost Host { get; set; }
        #endregion

        #region LogProperties

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        public NLog.LogLevel LogLevel { get; set; } = NLog.LogLevel.Trace;

        /// <summary>
        /// Gets or sets the log path to store log as file.
        /// </summary>
        public string LogPath { get; set; } = @"C:/Logs/ProcessText/ProcessText_WPF.log";

        /// <summary>
        /// Gets or sets the log max file size before rolling.
        /// </summary>
        public long LogMaxFileSize { get; set; } = 104857600;
        #endregion
    }
}
