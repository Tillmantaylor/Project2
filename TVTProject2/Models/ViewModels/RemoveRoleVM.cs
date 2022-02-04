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
    /// Remove role view model
    /// </summary>
    public class RemoveRoleVM
    {
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
