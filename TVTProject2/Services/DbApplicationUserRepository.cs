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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;

namespace TVTProject2.Services
{
    /// <summary>
    /// Manages database holding users
    /// </summary>
    public class DbApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Injects repositories
        /// </summary>
        public DbApplicationUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Assigns roles to a user
        /// params - username of the user rolename of the role being assigned
        /// </summary>
        public async Task AssignUserToRoleAsync(string userName, string roleName)
        {
            var roleCheck = await _roleManager.RoleExistsAsync(roleName);
            if (!roleCheck)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            var user = await ReadAsync(userName);
            if(user != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

        /// <summary>
        /// Creates a user async
        /// params - user being created password for the user
        /// </summary>
        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        /// <summary>
        /// Reads a user
        /// param - username of user being read
        /// </summary>
        public ApplicationUser Read(string userName)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == userName);
        }

        /// <summary>
        /// Reads a user async
        /// param - username of user being read
        /// </summary>
        public async Task<ApplicationUser> ReadAsync(string userName)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }
    }
}
