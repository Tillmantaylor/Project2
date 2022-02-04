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

namespace TVTProject2.Models.ViewModels
{
    /// <summary>
    /// Assign role view model
    /// </summary>
    public class AssignRoleVM
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
        public decimal HourlyRate { get; set; }
        public IEnumerable<AssignRoleOptions> AssignRoleOptions { get; set; }
        public int PersonId { get; set; }
    }
}
