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
    /// Assign person view model
    /// </summary>
    public class AssignPersonVM
    {
        [DisplayName("Project Name")]
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
        public int ProjectId { get; set; }

    }
}
