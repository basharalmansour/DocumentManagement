using CleanArchitecture.Domain.Entities.Definitions.SpecialRules;
using CleanArchitecture.Domain.Entities.Documents;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Polly;

namespace CleanArchitecture.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole("Administrator");

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }
    }

    public static async Task SeedDocumentTypeDataAsync(ApplicationDbContext context)
    {
        if (!context.DocumentTemplateTypes.Any())
        {
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Name = "General"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Name = "Personnel"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Name = "VehicleTemplate"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Name = "Special Process"
            });
            await context.SaveChangesAsync();
        }
    }
    public static async Task SeedSpecialRulsDataAsync(ApplicationDbContext context)
    {
        if (!context.SpecialRules.Any())
        {
            context.SpecialRules.Add(new SpecialRule
            {
                Name = "FireWorks"
            });
            context.SpecialRules.Add(new SpecialRule
            {
                Name = "SoundWorks"
            });
            await context.SaveChangesAsync();
        }
    }
}
