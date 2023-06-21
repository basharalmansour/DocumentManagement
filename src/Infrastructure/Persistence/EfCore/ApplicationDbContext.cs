using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.Definitions.Equipments;
using CleanArchitecture.Domain.Entities.Definitions.Roles;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.DocumentTemplates;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Orders;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Entities.UserGroups;
using CleanArchitecture.Domain.Entities.Vehicles;
using CleanArchitecture.Domain.Entities.VehicleTemplates;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Domain.Entities.Vendors;
using CleanArchitecture.Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
    public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
    public DbSet<DocumentTemplateFileType> DocumentTemplateFileTypes { get; set; }
    public DbSet<DocumentTemplateType> DocumentTemplateTypes { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<DateQuestionOptions> DateQuestionOptions { get; set; }
    public DbSet<FileQuestionOptions> FileQuestionOptions { get; set; }
    public DbSet<MultiChoicesOption> MultiChoicesOptions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<PresenceGroup> PresenceGroups { get; set; }
    public DbSet<PresenceGroupArea> PresenceGroupAreas { get; set; }
    public DbSet<PresenceGroupBlock> PresenceGroupBlocks { get; set; }
    public DbSet<PresenceGroupBrand> PresenceGroupBrands { get; set; }
    public DbSet<PresenceGroupCompany> PresenceGroupCompanys { get; set; }
    public DbSet<PresenceGroupSite> PresenceGroupSites { get; set; }
    public DbSet<PresenceGroupUnit> PresenceGroupUnits { get; set; }
    public DbSet<PresenceGroupZone> PresenceGroupZones { get; set; }
    public DbSet<DocumentTemplateArea> DocumentTemplateAreas { get; set; }
    public DbSet<DocumentTemplateBlock> DocumentTemplateBlocks { get; set; }
    public DbSet<DocumentTemplateBrand> DocumentTemplateBrands { get; set; }
    public DbSet<DocumentTemplateCompany> DocumentTemplateCompanies { get; set; }
    public DbSet<DocumentTemplateSite> DocumentTemplateSites { get; set; }
    public DbSet<DocumentTemplateUnit> DocumentTemplateUnits { get; set; }
    public DbSet<DocumentTemplateZone> DocumentTemplateZones { get; set; }
    public DbSet<DocumentTemplatePresenceGroup> DocumentTemplatePresenceGroups { get; set; }
    public DbSet<ResponsibleDepartment> ResponsibleDepartments { get; set; }
    public DbSet<ResponsiblePersonnel> ResponsiblePersonnels { get; set; }
    public DbSet<ResponsibleUserGroup> ResponsibleUserGroups { get; set; }
    public DbSet<ServiceCategoryRole> ServiceCategoryApprovments { get; set; }
    public DbSet<ServiceCategoryDocument> CategoryDocuments { get; set; }
    public DbSet<ServiceCategoryPersonnelDocument> CategoryPersonnelDocuments { get; set; }
    public DbSet<ServiceCategoryArea> ServiceCategoryAreas { get; set; }
    public DbSet<ServiceCategoryBlock> ServiceCategoryBlocks { get; set; }
    public DbSet<ServiceCategoryBrand> ServiceCategoryBrands { get; set; }
    public DbSet<ServiceCategoryCompany> ServiceCategoryCompanies { get; set; }
    public DbSet<ServiceCategorySite> ServiceCategorySites { get; set; }
    public DbSet<ServiceCategoryUnit> ServiceCategoryUnits { get; set; }
    public DbSet<ServiceCategoryZone> ServiceCategoryZones { get; set; }
    public DbSet<ServiceCategoryPresenceGroup> ServiceCategoryPresenceGroups { get; set; }
    public DbSet<ServiceCategoryVehicleTemplateDocument> ServiceCategoryVehicleTemplateDocuments { get; set; }
    public DbSet<ServiceCategoryVehicleTemplate> ServiceCategoryVehicleTemplates { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ServiceCategoryDetails> ServiceCategoryDetails { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserGroupPersonnel> UserGroupPersonnels { get; set; }
    public DbSet<VehicleTemplateDocument> VehicleTemplateDocuments { get; set; }
    public DbSet<VehicleTemplateDriverDocument> VehicleTemplateDriverDocuments { set; get; }
    public DbSet<PersonnelRole> PersonnelRoles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderEquipment> OrderEquipment { get; set; }
    public DbSet<OrderVehicle> OrderVehicles { get; set; }
    public DbSet<OrderVehicleDriver> OrderVehicleDrivers { get; set; }
    public DbSet<OrderPersonnel> OrderPersonnels { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<OrderVehicleDriverDocument> OrderVehicleDriverDocuments { get; set; }
    public DbSet<OrderPersonnelDocument> OrderPersonnelDocuments { get; set; }
    public DbSet<OrderServiceCategoryDocument> OrderServiceCategoryDocuments { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<VendorPersonnel> VendorPersonnels { get; set; }
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
            switch (entry.Entity.IsDeleted)
            {
                case true:
                    entry.Entity.DeletedDate = DateTimeNow;
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
