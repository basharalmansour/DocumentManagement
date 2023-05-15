using CleanArchitecture.Application.Common.Helpers;
using CleanArchitecture.Domain.Entities.Definitions.Equipments;
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
    public static async Task SeedEquipmentsDataAsync(ApplicationDbContext context)
    {
        if (!context.Equipments.Any())
        {
            var kesici = new LanguageString
            {
                { LanguageCode.tr, "Kesici" },
                { LanguageCode.en, "Cutter" }
            };

            var taslama = new LanguageString
            {
                { LanguageCode.tr, "Taşlama" },
                { LanguageCode.en, "Taşlama" }
            };

            context.Equipments.Add(new Equipment
            {
                Name = LanguageJsonFormatter.SerializObject(kesici),
                IsHeat= false,
                IsNoise= true,
                IsHidden= false,
            });
            context.Equipments.Add(new Equipment
            {
                Name = LanguageJsonFormatter.SerializObject(taslama),
                IsHeat= false,
                IsNoise= true,
                IsHidden= false,
            });
            await context.SaveChangesAsync();
        }
    }
}
