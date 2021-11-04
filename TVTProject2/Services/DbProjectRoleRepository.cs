using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public class DbProjectRoleRepository : IProjectRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public DbProjectRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ProjectRole Read(int id)
        {
            return _db.ProjectRoles.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<ProjectRole> ReadAll()
        {
            return _db.ProjectRoles
                 .ToList();
        }

        public ProjectRole Create(ProjectRole projectRole)
        {
            _db.ProjectRoles.Add(projectRole);
            _db.SaveChanges();
            return projectRole;
        }

        public async Task<ICollection<ProjectRole>> ReadAllByProjectIdAsync(int projectId)
        {
            return await _db.ProjectRoles.Where(projectRole => projectRole.ProjectId == projectId).ToListAsync();
        }
    }
}
