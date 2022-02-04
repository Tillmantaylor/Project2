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
    /// interfcae for project
    /// </summary>
    public interface IProjectRepository
    {
        ICollection<Project> ReadAll();
        Project Create(Project project);
        Project Read(int id);
        Task<Project> ReadAsync(int id);
        void Update(int oldId, Project project);
        void Delete(int id);
    }
}
