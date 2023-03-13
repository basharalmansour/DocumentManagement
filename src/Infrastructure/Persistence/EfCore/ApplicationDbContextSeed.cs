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
        //// Seed, if necessary
        //if (!context.TodoLists.Any())
        //{
        //    context.TodoLists.Add(new TodoList
        //    {
        //        Title = "Shopping",
        //        Colour = Colour.Blue,
        //        Items =
        //            {
        //                new TodoItem { Title = "Apples", Done = true },
        //                new TodoItem { Title = "Milk", Done = true },
        //                new TodoItem { Title = "Bread", Done = true },
        //                new TodoItem { Title = "Toilet paper" },
        //                new TodoItem { Title = "Pasta" },
        //                new TodoItem { Title = "Tissues" },
        //                new TodoItem { Title = "Tuna" },
        //                new TodoItem { Title = "Water" }
        //            }
        //    });

        //await context.SaveChangesAsync();
        if (!context.DocumentTemplateTypes.Any())
        {
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Id = 1,
                Name = "General"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Id = 2,
                Name = "Personnel"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Id = 3,
                Name = "Vehicle"
            });
            context.DocumentTemplateTypes.Add(new DocumentTemplateType
            {
                Id = 4,
                Name = "Special Process"
            });
            await context.SaveChangesAsync();
        }
    }
}
