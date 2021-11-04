using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public class Initializer
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppRoleRepository _appRoleRepo;
        
        public Initializer(
            ApplicationDbContext db, 
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IAppRoleRepository appRoleRepo)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
            _appRoleRepo = appRoleRepo;
        }

        public async Task SeedRolesAsync()
        {
            _db.Database.EnsureCreated();

            if (!_db.Roles.Any(role => role.Name == "Project Manager"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Project Manager" });
            }

            if (!_db.Users.Any(user => user.UserName == "Proman"))
            {
                var user = new ApplicationUser
                {
                    UserName = "Proman",
                    Email = "proman@test.com"
                };
                await _userManager.CreateAsync(user, "Admin1!");
                await _userManager.AddToRoleAsync(user, "Project Manager");
            }

            if (!_db.AppRoles.Any(role => role.Name == "Member"))
            {
                await _appRoleRepo.CreateAsync(new AppRole { Name = "Member" });
            }
        }
    }
}
