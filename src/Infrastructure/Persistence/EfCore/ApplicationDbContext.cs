using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Definitions;
using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;
using CleanArchitecture.Domain.Entities.Definitions.VehicleTemplates;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Entities.UserGroups;
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
    public DbSet<SpecialRule> SpecialRules { get; set; }
    public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
    public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
    public DbSet<DocumentTemplateFileType> DocumentTemplateFileTypes { get; set; }
    public DbSet<DocumentTemplateType> DocumentTemplateTypes { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<DateQuestionOptions> DateQuestionOptions { get; set; }
    public DbSet<FileQuestionOptions> FileQuestionOptions { get; set; }
    public DbSet<MultiChoicesQuestion> MultiChoicesQuestions { get; set; }
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
    public DbSet<ResponsibleDepartment> ApproverDepartments { get; set; }
    public DbSet<ResponsiblePersonnel> ApproverPersonnels { get; set; }
    public DbSet<ResponsibleUserGroup> ApproverUserGroups { get; set; }
    public DbSet<ServiceCategoryRole> ServiceCategoryApprovments { get; set; }
    public DbSet<CategoryDocument> CategoryDocuments { get; set; }
    public DbSet<CategoryPersonnelDocument> CategoryPersonnelDocuments { get; set; }
    public DbSet<ServiceCategoryArea> ServiceCategoryAreas { get; set; }
    public DbSet<ServiceCategoryBlock> ServiceCategoryBlocks { get; set; }
    public DbSet<ServiceCategoryBrand> ServiceCategoryBrands { get; set; }
    public DbSet<ServiceCategoryCompany> ServiceCategoryCompanies { get; set; }
    public DbSet<ServiceCategorySite> ServiceCategorySites { get; set; }
    public DbSet<ServiceCategoryUnit> ServiceCategoryUnits { get; set; }
    public DbSet<ServiceCategoryZone> ServiceCategoryZones { get; set; }
    public DbSet<ServiceCategoryPresenceGroup> ServiceCategoryPresenceGroups { get; set; }
    public DbSet<CategoryVehicleTemplateDocuments> CategoryVehicleDocuments { get; set; }
    public DbSet<VehicleTemplateCategory> VehicleCategories { get; set; }
    public DbSet<CategorySpecialRules> CategorySpecialRoles { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserGroupPersonnel> UserGroupPersonnels { get; set; }
    public DbSet<VehicleTemplatesDocument> VehiclesDocuments { get; set; }
    public DbSet<VehicleTemplateDriverDocuments> VehicleDriverDocuments { set; get; }
    public DbSet<PersonnelRole> PersonnelRoles { get; set; }
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
