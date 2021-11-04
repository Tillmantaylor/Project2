using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public class DbAppRoleRepository : IAppRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public DbAppRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public AppRole Create(AppRole appRole)
        {
            _db.AppRoles.Add(appRole);
            _db.SaveChanges();
            return appRole;
        }

        public async Task CreateAsync(AppRole appRole)
        {
            await _db.AppRoles.AddAsync(appRole);
            await _db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var appRoleToDelete = Read(id);
            _db.AppRoles.Remove(appRoleToDelete);
            _db.SaveChanges();
        }

        public AppRole Read(int id)
        {
            return _db.AppRoles.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<AppRole> ReadAll()
        {
            return _db.AppRoles
                .ToList();
        }

        public AppRole ReadByName(string name)
        {
            return _db.AppRoles.FirstOrDefault(role => role.Name == name);
        }

        public void Update(int oldId, AppRole appRole)
        {
            var appRoleToUpdate = Read(oldId);
            appRoleToUpdate.Id = appRole.Id;
            appRoleToUpdate.Name = appRole.Name;
            appRoleToUpdate.Description = appRole.Description;
            _db.SaveChanges();
        }
    }
}
