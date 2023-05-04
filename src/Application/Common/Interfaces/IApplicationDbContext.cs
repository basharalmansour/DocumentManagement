using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;
using CleanArchitecture.Domain.Entities.Definitions.Vehicles;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Domain.Entities.Forms;
using CleanArchitecture.Domain.Entities.Presences.PresenceGroups;
using CleanArchitecture.Domain.Entities.Presences.PresencesDocumentTemplates;
using CleanArchitecture.Domain.Entities.SeviceCategories.Approvers;
using CleanArchitecture.Domain.Entities.SeviceCategories.Documents;
using CleanArchitecture.Domain.Entities.SeviceCategories.Presences;
using CleanArchitecture.Domain.Entities.SeviceCategories.Vehicles;
using CleanArchitecture.Domain.Entities.SeviceCategories;
using CleanArchitecture.Domain.Entities.UserGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<SpecialRule> SpecialRules { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
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
    public DbSet<ServiceCategoryPresenceGroup> ServiceCategoryPresenceGroups { get; set; }
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
    public DbSet<CategoryVehicleTemplateDocuments> CategoryVehicleDocuments { get; set; }
    public DbSet<VehicleTemplateCategory> VehicleCategories { get; set; }
    public DbSet<CategorySpecialRules> CategorySpecialRoles { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserGroupPersonnel> UserGroupPersonnels { get; set; }
    public DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
    
}
