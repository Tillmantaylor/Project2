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

namespace TVTProject2.Models.ViewModels
{
    /// <summary>
    /// Remove person view model
    /// </summary>
    public class RemovePersonVM
    {
        public string ProjectName { get; set; }
        public Person Person { get; set; }
        public IEnumerable<string> ProjectRoles { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
    }
}
