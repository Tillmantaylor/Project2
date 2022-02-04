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
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;

namespace TVTProject2.Models.ViewModels
{
    /// <summary>
    /// project report view model
    /// </summary>
    public class ProjectReportVM
    {
        public IEnumerable<ProjectMetadata> Projects { get; set; }
    }

    public class ProjectMetadata
    {
        public string Name { get; set; }
        public decimal TotalHourlyRate { get; set; }
        public IEnumerable<PersonMetadata> People { get; set; }
    }

    public class PersonMetadata
    {
        public string Name { get; set; }
        public string RoleName { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
