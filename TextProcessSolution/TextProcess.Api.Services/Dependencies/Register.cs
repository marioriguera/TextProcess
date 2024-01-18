using Microsoft.Extensions.DependencyInjection;
using TextProcess.Api.Core.Business.Analyzer;
using TextProcess.Api.Core.Business.Factory;
using TextProcess.Api.Core.Business.Order;
using TextProcess.Api.Core.Contracts.Factories;
using TextProcess.Api.Core.Contracts.Services;

namespace TextProcess.Api.Core.Dependencies
{
    /// <summary>
    /// Register core layer dependency injections
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Configure and register the necessary dependencies in the application's dependency injection container.
        /// </summary>
        /// <param name="services">The collection of services to which the dependencies will be added.</param>
        /// <returns>The same collection of services with dependencies added.</returns>
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<IOrderOptionsService, OrderOptionsService>();
            services.AddScoped<ITextAnalyzerService, TextAnalyzerService>();
            return services;
        }
    }
}
