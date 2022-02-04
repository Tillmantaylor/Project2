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
    /// project role details view model
    /// </summary>
    public class ProjectRoleDetailsVM
    {
        public int Id { get; set; }
        [DisplayName("Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [DisplayName("Person Id")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [DisplayName("Project Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [DisplayName("AppRole Id")]
        public int AppRoleId { get; set; }
    }
}
