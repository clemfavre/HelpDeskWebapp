using Microsoft.AspNetCore.Identity;
using HelpDeskWebapp.Models;
using System.Runtime.InteropServices;

public static class DbSeeder
{
    public static async Task SeedRolesAndAdmin (IServiceProvider isp)
    {
        var userManager = isp.GetService<UserManager<User>>();
        var roleManager = isp.GetService<RoleManager<IdentityRole>>();

        //create roles if not already done
        if (!await roleManager.RoleExistsAsync("client"))
        {
            await roleManager.CreateAsync(new IdentityRole("client"));
        }
        if (!await roleManager.RoleExistsAsync("ITsupport"))
        {
            await roleManager.CreateAsync(new IdentityRole("ITsupport"));
        }

        //create 5 ITsupport members
        string email = "itsup@";
        string pseudo = "ITsupport ";
        string mdp = "T0D0:addSecrets";
        for (int i=1; i<=5; i++)
        {
            await CreateItSupport(userManager, email + i.ToString(), pseudo + i.ToString(), mdp);
        }
    }

    private static async Task CreateItSupport(UserManager<User> um, string email, string pseudo, string mdp)
    {
        var itSupUser = await um.FindByEmailAsync(email);
        if (itSupUser==null)
        {
            var newItSupUser = new User
            {
                UserName = email,
                Pseudo = pseudo,
                Email = email
            };
            await um.CreateAsync(newItSupUser, mdp);
            await um.AddToRoleAsync(newItSupUser, "ITsupport");
        }
    }
}