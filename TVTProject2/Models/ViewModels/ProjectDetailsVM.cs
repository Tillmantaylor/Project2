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
using TVTProject2.Models;

namespace TVTProject2.Models.ViewModels
{
    /// <summary>
    /// project details view model
    /// </summary>
    public class ProjectDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectDue { get; set; }
        public IEnumerable<PersonRole> People { get; set; }
        public int ProjectId { get; set; }
        public ICollection<ProjectRole> ProjectRoles { get; set; }
            = new List<ProjectRole>();
    }
}
