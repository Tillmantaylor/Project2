using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;

namespace TVTProject2.Services
{
    public class DbApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbApplicationUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

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

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        public ApplicationUser Read(string userName)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public async Task<ApplicationUser> ReadAsync(string userName)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }
    }
}
