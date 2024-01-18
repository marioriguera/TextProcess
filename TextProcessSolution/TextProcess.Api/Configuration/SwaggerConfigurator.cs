using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TextProcess.Api.Configuration
{
    /// <summary>
    /// Provides extension methods for configuring Swagger in the IServiceCollection.
    /// </summary>
    public static class SwaggerConfigurator
    {
        /// <summary>
        /// Configures Swagger generation for the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to configure Swagger for.</param>
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                ConfigureSwaggerDoc(c);
            });
        }

        /// <summary>
        /// Configures the Swagger document information.
        /// </summary>
        /// <param name="options">The SwaggerGenOptions to configure.</param>
        private static void ConfigureSwaggerDoc(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Text Process",
                Version = "v1",
                Description = "An ASP.NET Core Web API for managing text process",
                Contact = new OpenApiContact
                {
                    Name = "Mario David Riguera Castillo",
                    Url = new Uri("https://www.linkedin.com/in/mario-david-riguera-castillo/"),
                },
            });
        }
    }
}
