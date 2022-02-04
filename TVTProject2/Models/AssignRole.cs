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

namespace TVTProject2.Models
{
    /// <summary>
    /// Assign Role view model
    /// </summary>
    public class AssignRole
    {
        public int ProjectId { get; set; }
        public decimal HourlyRate { get; set; }
        public string Role { get; set; }
        public int PersonId { get; set; }
    }

    /// <summary>
    /// Options for view model
    /// </summary>
    public class AssignRoleOptions
    {
        public string Name { get; set; }
    }
}
