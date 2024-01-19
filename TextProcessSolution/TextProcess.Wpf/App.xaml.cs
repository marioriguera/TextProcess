using System.Windows;
using Microsoft.Extensions.Hosting;
using TextProcess.Wpf.Configuration;
using TextProcess.Wpf.Core.Dependencies;

namespace TextProcess.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ConfigurationService.Current.Host = Host.CreateDefaultBuilder().AddCoreDependencies().Build();
        }

        /// <inheritdoc/>
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);

                NLogConfigurator.Initialize();
                NLogConfigurator.AddDebugger();
                NLogConfigurator.ApplyConfigurationToLogs();

                MainWindow = new MainWindow();
                MainWindow.Show();

                ConfigurationService.Current.Logger.Info($"Application started.");
            }
            catch (Exception ex)
            {
                ConfigurationService.Current.Logger.Fatal(ex, $"An unhandled exception has occurred at the time of starting the application.");
            }
        }
    }
}
