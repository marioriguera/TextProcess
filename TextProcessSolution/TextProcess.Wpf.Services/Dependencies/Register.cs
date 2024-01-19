using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextProcess.Wpf.Core.Business;
using TextProcess.Wpf.Core.Connections;
using TextProcess.Wpf.Core.Contracts.Connections;
using TextProcess.Wpf.Core.Contracts.Services;
using TextProcess.Wpf.Core.Contracts.Utils;
using TextProcess.Wpf.Core.Utils;

namespace TextProcess.Wpf.Core.Dependencies
{
    /// <summary>
    /// Provides extension methods to register core dependencies.
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Adds core dependencies to the specified host builder.
        /// </summary>
        /// <param name="hostBuilder">The IHostBuilder to configure.</param>
        /// <returns>The configured IHostBuilder.</returns>
        public static IHostBuilder AddCoreDependencies(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddScoped<IHttpManager, HttpManager>();
                services.AddScoped<IOrderService, OrderService>();
                services.AddScoped<ITextStatisticsService, TextStatisticsService>();
                services.AddScoped<ITextManager, TextManager>();
            });

            return hostBuilder;
        }
    }
}
