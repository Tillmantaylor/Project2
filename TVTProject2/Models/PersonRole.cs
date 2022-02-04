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

namespace TVTProject2.Models
{
    /// <summary>
    /// person role view model
    /// </summary>
    public class PersonRole
    {
        public string Name { get; set; }
        public IEnumerable<string> projectRoles { get; set; }
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
    }
}
