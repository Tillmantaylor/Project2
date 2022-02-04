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
    /// Project database CRUD functions
    /// </summary>
    public class DbProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Injects database
        /// </summary>
        public DbProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates a project in the database
        /// params - Project that holds information needed to create a project
        /// </summary>
        public Project Create(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        /// <summary>
        /// Deleted a project from the database
        /// params - Id pointing to the project wanting to be deleted
        /// </summary>
        public void Delete(int id)
        {
            var projectToDelete = Read(id);
            _db.Projects.Remove(projectToDelete);
            _db.SaveChanges();
        }

        /// <summary>
        /// Reads a project
        /// params - Id pointing to a project you want to read
        /// </summary>
        public Project Read(int id)
        {
            return _db.Projects.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Reads all the porjects in the database
        /// </summary>
        public ICollection<Project> ReadAll()
        {
            return _db.Projects
                .ToList();
        }

        /// <summary>
        /// Reads project async
        /// params - Id pointing to a specific project
        /// </summary>
        public async Task<Project> ReadAsync(int id)
        {
            return await _db.Projects.FindAsync(id);
        }

        /// <summary>
        /// Updates project with different information 
        /// params - oldId pointing to project needing update Project with holding changes
        /// </summary>
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
