using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Debugging;
using Serilog.Formatting.Elasticsearch;
using Serilog.Settings.Configuration;
namespace CleanArchitecture.WebUI;

public class Program
{
    public async static Task Main(string[] args)
    {
        try
        {

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var elasticSearchSettings = scope.ServiceProvider.GetService<IOptions<AppSettings>>()?.Value.ElasticSearchOptions;
                var services = scope.ServiceProvider;
                var env = services.GetRequiredService<IWebHostEnvironment>();
                var config = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", false)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true).Build();
                SelfLog.Enable(Console.Error);
                var elasticOptions = new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(elasticSearchSettings.HostUrls));


                elasticOptions.ModifyConnectionSettings = x => x.BasicAuthentication(elasticSearchSettings?.UserName, elasticSearchSettings?.Password);
                elasticOptions.IndexDecider = (@event, offset) => elasticSearchSettings?.Node;
                elasticOptions.CustomFormatter = new ElasticsearchJsonFormatter();
                elasticOptions.IndexFormat = "IntegrationApi-log-{0:yyyy.MM.dd}";


                Log.Logger = new LoggerConfiguration()
               .Enrich.WithThreadId()
               .Enrich.WithThreadName()
               .Enrich.WithMachineName()
               .Enrich.WithEnvironmentUserName()
               .Enrich.FromLogContext()
               .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
               .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
               .WriteTo.Elasticsearch(elasticOptions)
               .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
               .CreateLogger();

                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
                    await ApplicationDbContextSeed.SeedDocumentTypeDataAsync(context);
                    await ApplicationDbContextSeed.SeedEquipmentsDataAsync(context);
                    await host.RunAsync();

                }

            }
        }
        catch (Exception e)
        {
            throw;
        }


    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureLogging(logging => logging.ClearProviders())
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.UseStartup<Startup>());
}
