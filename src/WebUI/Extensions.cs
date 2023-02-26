using System.Text;
using CleanArchitecture.Application.Common.Dtos.CondoLife;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Services;
using Consul;
using MassTransit;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace CleanArchitecture.WebUI;

public static class Extensions
{

    public static IServiceCollection ConfigureJWTToken(this IServiceCollection services, IConfiguration Configuration)
    {
          
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {

            options.Audience = Configuration["IdentityServer:Audience"];
            options.TokenValidationParameters.ValidIssuer = Configuration["IdentityServer:Audience"];
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["IdentityServer:JwtKey"]));
            options.TokenValidationParameters.ValidateIssuerSigningKey = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters.ValidAudience = Configuration["IdentityServer:Audience"];
            options.TokenValidationParameters.ValidateAudience = false;
            options.TokenValidationParameters.ValidateIssuer = false;
            options.TokenValidationParameters.ValidIssuer = Configuration["IdentityServer:Audience"];
            options.TokenValidationParameters.ValidateLifetime = true;

        });
        return services;
    }

    public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var massTransitConnectionStr = configuration.GetConnectionString("RabbitMqConnection");
        services.AddMassTransit(x =>
        {
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri(massTransitConnectionStr), h =>
                {
                    h.Username(configuration["RabbitMq:User"]);
                    h.Password(configuration["RabbitMq:Pass"]);
                });
            }));
        });
        services.AddMassTransitHostedService();
    }
    
    public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var connectionString = configuration.GetConnectionString("RedisConnection");
            
            var redisConnection = ConnectionMultiplexer.Connect(connectionString);
            services.AddSingleton<IConnectionMultiplexer>(redisConnection);

            var redisDb = redisConnection.GetDatabase(RedisDatabaseKeys.IntegrationProjectRedis);
            services.AddSingleton(redisDb);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
        {
            var address = configuration["consulConfig:Address"];
            consulConfig.Address = new Uri(address);
            consulConfig.Token = configuration["consulConfig:Token"];
        }));

        return services;
    }


    public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, IConfiguration configuration)
    {
        var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

        var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

        var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

        var address = configuration["consulConfig:APIAddress"];
        var uri = new Uri(address);
        var registration = new AgentServiceRegistration()
        {
            ID = $"CondoLife.API.Integration",
            Name = "CondoLife.API.Integration",
            Address = $"{uri.Host}",
            Port = uri.Port,
            Tags = new[] { "CondoLife Integration Service", "Integration" }
        };

        logger.LogInformation("CondoLife.API.Integration - Registering with Consul");
        try
        {
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CondoLife.API.Integration - Registering with Consul");
        }

        return app;
    }
}