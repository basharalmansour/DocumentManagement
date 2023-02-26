using System.Reflection;
using CleanArchitecture.Application.Common.Dtos.Orders;
using CleanArchitecture.Application.Common.Dtos.POI.Cart.RequestDtos;
using CleanArchitecture.Application.Common.Dtos.VeriSoft.Customer.RequestDtos;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Products;
using CleanArchitecture.Infrastructure.Files;
using CleanArchitecture.Infrastructure.HttpClients.CondoLife;
using CleanArchitecture.Infrastructure.HttpClients.Handlers;
using CleanArchitecture.Infrastructure.HttpClients.Hotel;
using CleanArchitecture.Infrastructure.HttpClients.TAV;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.MongoDb;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using Polly;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            var connectionSTring = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IOtpSmsService, OtpSmsService>();
            
        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
        services.AddScoped<CondoLifeAuthorizationAdapter>();
        services.AddTransient<CondoLifeHttpClientAuthHandler>();
        services.AddTransient<PoiHttpClientAuthHandler>();
        services.AddTransient<PoiHttpClientExceptionHandler>();
        services.AddTransient<HttpClientLoggingHandler>();
        services.AddTransient<VeriSoftHttpClientExceptionHandler>();
        services.AddHttpClient<IVeriSoftHttpClient, VeriSoftHttpClient>(x =>
            {
                x.DefaultRequestHeaders.Clear();
                x.DefaultRequestHeaders.Add("XXX-ClientKey", configuration.GetSection("ClientSettings:VeriSoft:ClientKey").Value);
                x.BaseAddress = new Uri(configuration["ClientSettings:VeriSoft:BaseUrl"]);
            })
            .AddHttpMessageHandler<VeriSoftHttpClientExceptionHandler>()
            .AddHttpMessageHandler<HttpClientLoggingHandler>()
            .AddTransientHttpErrorPolicy(policyBuilder =>
            policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));

        services.AddHttpClient<ICondolifeHttpClient, CondoLifeHttpClient>(x =>
            {
                x.BaseAddress = new Uri(configuration["ClientSettings:CondoLife:BaseUrl"]);
            })
            .AddHttpMessageHandler<CondoLifeHttpClientAuthHandler>()
            .AddHttpMessageHandler<HttpClientLoggingHandler>()
            .AddTransientHttpErrorPolicy(policyBuilder =>
            policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));

        services.AddHttpClient<IPoiHttplClient, PoiHttpClient>(x =>
            {
                x.BaseAddress = new Uri(configuration["ClientSettings:POI:BaseUrl"]);
            })
            .AddHttpMessageHandler<PoiHttpClientExceptionHandler>()
            .AddHttpMessageHandler<PoiHttpClientAuthHandler>()
            .AddHttpMessageHandler<HttpClientLoggingHandler>()
            .AddTransientHttpErrorPolicy(policyBuilder =>
            policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));
        
        services.AddHttpClient<IHotelHttpClient, HotelHttpClient>(x =>
            {
                x.BaseAddress = new Uri(configuration["ClientSettings:Hotel:BaseUrl"]);
            })
            .AddHttpMessageHandler<HttpClientLoggingHandler>()
            .AddTransientHttpErrorPolicy(policyBuilder =>
                policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));
        
        #region MongoDb repository register
        
        services.AddSingleton<IMongoDbRepository<OrderProperties>, BaseRepository<OrderProperties>>();
        services.AddSingleton<IMongoDbRepository<OrderPropertyDetails>, BaseRepository<OrderPropertyDetails>>();

        BsonClassMap.RegisterClassMap<OrderDetailDto>();
        BsonClassMap.RegisterClassMap<VerisoftCreateCustomerRequestDto>();
        BsonClassMap.RegisterClassMap<CartCheckOutTransferRequestDto>();
        
        #endregion
        
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }

    public static IServiceCollection RegisterMongoRepository(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoEntites = Assembly.GetExecutingAssembly().GetTypes().Where(x => x is MongoDbEntity).ToList();
    

        return services;
    }
}
