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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models.Entities;
using TVTProject2.Models.ViewModels;
using TVTProject2.Services;

namespace TVTProject2.Controllers
{
    public class ProjectRoleController : Controller
    {
        private readonly IProjectRoleRepository _projectRoleRepo;

        /// <summary>
        /// Injects repository
        /// </summary>
        public ProjectRoleController(IProjectRoleRepository projectRoleRepo)
        {
            _projectRoleRepo = projectRoleRepo;
        }

        /// <summary>
        /// Index showing basic information about project roles
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Index()
        {
            var allProjectRoles = _projectRoleRepo.ReadAll();
            var model = allProjectRoles.Select(pj =>
            new ProjectRoleDetailsVM
            {
                Id = pj.Id,
                HourlyRate = pj.HourlyRate,
                PersonId = pj.PersonId,
                ProjectId = pj.ProjectId,
                AppRoleId = pj.AppRoleId
            });
            return View(model);
        }
    }
}
