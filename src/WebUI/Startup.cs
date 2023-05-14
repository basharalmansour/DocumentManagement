using CleanArchitecture.Application;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.WebUI.Filters;
using CleanArchitecture.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Services;
using Hangfire;
using CleanArchitecture.Infrastructure.BackgroundJobs;
using AutoWrapper;

namespace CleanArchitecture.WebUI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure(Configuration);
        services.AddApplication(Configuration);
       

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = true);

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options => 
            options.SuppressModelStateInvalidFilter = true);

        services.Configure<AppSettings>(Configuration);
        services.ConfigureJWTToken(Configuration);
        services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {   
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
            // https://github.com/aspnet/SignalR/issues/2110 for AllowCredentials
        }));
        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "Integration Project API";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
        
        services.ConfigureMassTransit(Configuration);
        services.AddScoped<IMessageBrokerService, MessageBrokerService>();
        services.ConfigureConsul(Configuration);
        //services.ConfigureRedis(Configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        if (env.IsDevelopment() || env.EnvironmentName == "Test")
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/swagger";
                settings.DocumentPath = "/api/specification.json";
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {

            DashboardTitle = "CondoLifeIntegration Hangfire Dashboard", //Dashboard ekranındaki başlık alanı.
            AppPath = "", //Dashboard üzerindeki "back to site" butonu,
        });

        GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 7 });

        app.UseRouting();

        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseCors("CorsPolicy");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });

        //app.RegisterWithConsul(lifetime, Configuration);
        RecurringJobs.UpdateOrderDetailStatusesOperation();
    }
}
