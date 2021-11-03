using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Services
{
    public interface IApplicationUserRepository
    {
        ApplicationUser Read(string userName);
        Task<ApplicationUser> ReadAsync(string userName);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task AssignUserToRoleAsync(string userName, string roleName);
    }
}
