using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Basket;
using CleanArchitecture.Domain.Entities.Cities;
using CleanArchitecture.Domain.Entities.Counties;
using CleanArchitecture.Domain.Entities.Countries;
using CleanArchitecture.Domain.Entities.Integrations;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Products;
using CleanArchitecture.Domain.Entities.Sms;
using CleanArchitecture.Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
     
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        ICurrentUserService currentUserService,

        IDateTime dateTime) : base(options, operationalStoreOptions)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }
    public DbSet<Integration> Integrations { get; set; }
    public DbSet<SiteIntegration> SiteIntegrations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Sms> Sms { get; set; }
    public DbSet<TransferBasket> TransferBaskets { get; set; }
    public DbSet<IntegrationCountry> IntegrationCountries { get; set; }
    private void ConfigureAuditableStates()
    {
        var DateTimeNow = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries<IAuditable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedDate = DateTimeNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModifiedDate = DateTimeNow;
                    break;
            }
        }
    }
    private void ConfigureDeletableStates()
    {
        var DateTimeNow = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.Entity.DeletedDate = DateTimeNow;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedBy = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
                    break;
            }
        }
    }
    
    public override int SaveChanges()
    {
        ConfigureAuditableStates();
        ConfigureDeletableStates();
        return base.SaveChanges();
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ConfigureAuditableStates();
        ConfigureDeletableStates();

        var result = await base.SaveChangesAsync(cancellationToken);


        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }


}
