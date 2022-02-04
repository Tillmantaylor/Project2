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
using TVTProject2.Models.Entities;

namespace TVTProject2.Services
{
    /// <summary>
    /// Interface for approle
    /// </summary>
    public interface IAppRoleRepository
    {
        ICollection<AppRole> ReadAll();
        AppRole Create(AppRole appRole);
        Task CreateAsync(AppRole appRole);
        AppRole Read(int id);
        AppRole ReadByName(string name);
        void Update(int oldId, AppRole appRole);
        void Delete(int id);
    }
}
