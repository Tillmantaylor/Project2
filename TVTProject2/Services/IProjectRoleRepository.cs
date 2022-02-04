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
    /// Interface for project role
    /// </summary>
    public interface IProjectRoleRepository
    {
        ICollection<ProjectRole> ReadAll();
        Task<ICollection<ProjectRole>> ReadAllByProjectIdAsync(int projectId);
        Task<ICollection<ProjectRole>> ReadAllByProjectIdAndPersonIdAsync(int projectId, int personId);
        Task<ICollection<ProjectRole>> ReadAllByPersonIdAsync(int personId);
        ProjectRole Read(int id);
        ProjectRole Create(ProjectRole projectRole);
        void Delete(int id);
    }
}
