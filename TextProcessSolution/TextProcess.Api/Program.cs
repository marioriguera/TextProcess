using NLog;
using TextProcess.Api.Configuration;

namespace TextProcess.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            NlogConfigurator.Initialize();
            NlogConfigurator.AddConsole();
            NlogConfigurator.AddDebugger();
            NlogConfigurator.Start();

            var logger = LogManager.GetCurrentClassLogger();
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

                logger.Fatal($"The API will start.");
                app.Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
