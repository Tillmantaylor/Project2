///////////////////////////////////////////////////////////////////////////////////////////////////
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
    /// Person report view model
    /// </summary>
    public class PersonReportVM
    {
        public IEnumerable<PersonReportPersonMetadata> people { get; set; }
    }

    public class PersonReportPersonMetadata
    {
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public IEnumerable<PersonReportProjectMetadata> Projects { get; set; }
    }

    public class PersonReportProjectMetadata
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
