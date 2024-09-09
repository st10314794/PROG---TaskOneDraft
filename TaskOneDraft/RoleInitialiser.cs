using Microsoft.AspNetCore.Identity;
using TaskOneDraft.Areas.Identity.Data;

namespace TaskOneDraft
{
    public class RoleInitialiser
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                //Make sure Admin role exists -- if not create it
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                //Make sure Lecturer role exists -- if not create it

                if (!await roleManager.RoleExistsAsync("Lecturer"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Lecturer"));
                }



                // Check and create admin user
                var user = await userManager.FindByEmailAsync("adminguy@gmail.com");
                if (user == null)
                {
                    user = new ApplicationUser { UserName = "adminguy@gmail.com", Email = "adminguy@gmail.com", EmailConfirmed = true };
                    var result = await userManager.CreateAsync(user, "Mikhaeel!23");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        // Handle potential errors during user creation
                        throw new InvalidOperationException("Failed to create the admin user: " + result.Errors.FirstOrDefault()?.Description);
                    }
                }
            }
        }
    }
}
