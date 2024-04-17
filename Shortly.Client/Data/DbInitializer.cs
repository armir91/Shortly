using Microsoft.AspNetCore.Identity;
using Shortly.Data;
using Shortly.Data.Models;

namespace Shortly.Client.Data
{
    public static class DbInitializer
    {
        /*public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!dbContext.Users.Any())
                {
                    dbContext.Users.AddRange(new Shortly.Data.Models.AppUser()
                    {
                        FullName = "Armir Keta",
                        Email = "armir.keta@gmail.com"
                    });

                    dbContext.SaveChanges();
                }

                if (!dbContext.Urls.Any())
                {
                    dbContext.Urls.AddRange(new Shortly.Data.Models.Url()
                    {
                        OriginalLink = "https://dotnethow.net",
                        ShortLink = "dnh",
                        NrOfClicks = 20,
                        DateCreated = DateTime.Now,

                        UserId = dbContext.Users.First().Id
                    });

                    dbContext.SaveChanges();
                }
            }
        }*/

        public static async Task SeedDefaultUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                //Simple User related data

                var simpleUserRole = "User";
                var simpleUserEmail = "user@shortly.com";
                if (!await roleManager.RoleExistsAsync(simpleUserRole))
                    await roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = simpleUserRole
                    });
                
                if(await userManager.FindByEmailAsync(simpleUserEmail) == null)
                {
                    var simpleUser = new AppUser()
                    {
                        FullName = "John Doe",
                        UserName = "john-doe",
                        Email = simpleUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(simpleUser, "Password@1234!");


                    //Add user to role
                    await userManager.AddToRoleAsync(simpleUser, simpleUserRole);
                }


                //Admin user related data

                var adminUserRole = "Admin";
                var adminUserEmail = "admin@shortly.com";
                if (!await roleManager.RoleExistsAsync(adminUserRole))
                    await roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = adminUserRole
                    });

                if (await userManager.FindByEmailAsync(adminUserEmail) == null)
                {
                    var adminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Coding@1234!");


                    //Add user to role
                    await userManager.AddToRoleAsync(adminUser, adminUserRole);
                }
            }
        }
    }
}
