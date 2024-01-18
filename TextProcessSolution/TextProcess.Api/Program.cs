using TextProcess.Api.Configuration;

namespace TextProcess.Api
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to start the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            NlogConfigurator.Initialize();
            NlogConfigurator.AddConsole();
            NlogConfigurator.AddDebugger();
            NlogConfigurator.Start();

            try
            {
                // Apply configs
                NlogConfigurator.ApplyConfigurationToLogs();

                // Add services to the container.
                TextProcess.Api.Core.Dependencies.Register.AddDependencies(builder.Services);

                builder.Services.AddControllers();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.ConfigureSwaggerGen();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                ConfigurationService.Current.Logger.Fatal($"The API will start.");
                app.Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                ConfigurationService.Current.Logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
