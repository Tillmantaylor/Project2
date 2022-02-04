using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    /// <summary>
    /// Database changes for project role
    /// </summary>
    public class DbProjectRoleRepository : IProjectRoleRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Injects database
        /// </summary>
        public DbProjectRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Reads a project role
        /// params - Id of project role wanting to be read
        /// </summary>
        public ProjectRole Read(int id)
        {
            return _db.ProjectRoles.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Reads all project roles
        /// </summary>
        public ICollection<ProjectRole> ReadAll()
        {
            return _db.ProjectRoles
                 .ToList();
        }

        /// <summary>
        /// Creates a project role in database
        /// params - 
        /// </summary>
        public ProjectRole Create(ProjectRole projectRole)
        {
            _db.ProjectRoles.Add(projectRole);
            _db.SaveChanges();
            return projectRole;
        }

        /// <summary>
        /// Reads all project roles in a project
        /// params - projectId pointing to a specific project
        /// </summary>
        public async Task<ICollection<ProjectRole>> ReadAllByProjectIdAsync(int projectId)
        {
            return await _db.ProjectRoles.Where(projectRole => projectRole.ProjectId == projectId).ToListAsync();
        }

        /// <summary>
        /// Deletes a project role
        /// params - Id of project role that needs to be deleted
        /// </summary>
        public void Delete(int id)
        {
            var projectRoleToDelete = Read(id);
            _db.ProjectRoles.Remove(projectRoleToDelete);
            _db.SaveChanges();
        }

        /// <summary>
        /// Reads projects roles for a given person in a project
        /// params - projectId pointing to specific project personId pointing to a person
        /// </summary>
        public async Task<ICollection<ProjectRole>> ReadAllByProjectIdAndPersonIdAsync(int projectId, int personId)
        {
            return await _db.ProjectRoles.Where(projectRole => projectRole.ProjectId == projectId && projectRole.PersonId == personId).ToListAsync();
        }

        /// <summary>
        /// Reads all project roles for a person
        /// params - personId for person we want to read by
        /// </summary>
        public async Task<ICollection<ProjectRole>> ReadAllByPersonIdAsync(int personId)
        {
            return await _db.ProjectRoles.Where(projectRole => projectRole.PersonId == personId).ToListAsync();
        }
    }
}
