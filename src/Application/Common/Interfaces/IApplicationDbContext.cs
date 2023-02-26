using CleanArchitecture.Domain.Entities.Basket;
using CleanArchitecture.Domain.Entities.Cities;
using CleanArchitecture.Domain.Entities.Counties;
using CleanArchitecture.Domain.Entities.Countries;
using CleanArchitecture.Domain.Entities.Integrations;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Products;
using CleanArchitecture.Domain.Entities.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Integration> Integrations { get; set; }
    public DbSet<SiteIntegration> SiteIntegrations { get; set; }
    public DbSet<CleanArchitecture.Domain.Entities.Orders.Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Sms> Sms { get; set; }
    public DbSet<TransferBasket> TransferBaskets { get; set; }
    public DbSet<IntegrationCountry> IntegrationCountries { get; set; }
    public DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
    
}
