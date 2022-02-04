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

        /// <summary>
        /// Injects database
        /// </summary>
        public DbAppRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates approle in database
        /// param - approle information needed for creation
        /// </summary>
        public AppRole Create(AppRole appRole)
        {
            _db.AppRoles.Add(appRole);
            _db.SaveChanges();
            return appRole;
        }

        /// <summary>
        /// creates an approle async
        /// param - approle that is being added to database
        /// </summary>
        public async Task CreateAsync(AppRole appRole)
        {
            await _db.AppRoles.AddAsync(appRole);
            await _db.SaveChangesAsync();
        }


        /// <summary>
        /// Removes approle from databsse
        /// param - id of approle being deleted
        /// </summary>
        public void Delete(int id)
        {
            var appRoleToDelete = Read(id);
            _db.AppRoles.Remove(appRoleToDelete);
            _db.SaveChanges();
        }

        /// <summary>
        /// Reads an approle from the database
        /// param - id of approle being read
        /// </summary>
        public AppRole Read(int id)
        {
            return _db.AppRoles.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Reads all the approles
        /// </summary>
        public ICollection<AppRole> ReadAll()
        {
            return _db.AppRoles
                .ToList();
        }

        /// <summary>
        /// Read approle by the name of the roll
        /// param - name of an approle
        /// </summary>
        public AppRole ReadByName(string name)
        {
            return _db.AppRoles.FirstOrDefault(role => role.Name == name);
        }

        /// <summary>
        /// Update an approle
        /// params - oldId of approle being changed appRole with the information needed to be added to database
        /// </summary>
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
