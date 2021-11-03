using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Data;
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    public class DbProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public DbProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Project Create(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        public void Delete(int id)
        {
            var projectToDelete = Read(id);
            _db.Projects.Remove(projectToDelete);
            _db.SaveChanges();
        }

        public Project Read(int id)
        {
            return _db.Projects.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Project> ReadAll()
        {
            return _db.Projects
                .ToList();
        }

        public void Update(int oldId, Project project)
        {
            var projectToUpdate = Read(oldId);
            projectToUpdate.Name = project.Name;
            projectToUpdate.StartDate = project.StartDate;
            projectToUpdate.DueDate = project.DueDate;
            _db.SaveChanges();
        }
    }
}
