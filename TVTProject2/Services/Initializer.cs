////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project2
//  File Name:      TVTProject2.cs
//  Description:    Project Manager
//  Course:         CSCI-3110-001
//  Author:         Taylor Tillman, tillmant@etsu.edu
//  Created:        Saturday, November 6, 2021
//  Copyright:      Taylor Tillman, 2021
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    /// <summary>
    /// Used for beginning setup
    /// </summary>
    public class Initializer
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppRoleRepository _appRoleRepo;

        /// <summary>
        /// Injects needed inputs
        /// </summary>
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

        /// <summary>
        /// Creates roles and creates a Proman user as well as a member approle
        /// </summary>
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
