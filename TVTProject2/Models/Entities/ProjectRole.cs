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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TVTProject2.Models.Entities
{
    /// <summary>
    /// ProjectRole Model
    /// </summary>
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }

        [Range(8, 100)]
        [Column(TypeName = "decimal(18,4")]
        public decimal HourlyRate { get; set; }
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [ForeignKey("AppRoleId")]
        public int AppRoleId { get; set; }
    }
}
