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
using TVTProject2.Services;

namespace TVTProject2.Controllers
{
    public class AppRoleController : Controller
    {
        private readonly IAppRoleRepository _appRoleRepo;
        /// <summary>
        /// Injects repository
        /// </summary>
        public AppRoleController(IAppRoleRepository appRoleRepo)
        {
            _appRoleRepo = appRoleRepo;
        }

        /// <summary>
        /// Index View
        /// </summary>
        public IActionResult Index()
        {
            var model = _appRoleRepo.ReadAll();
            return View(model);
        }

        /// <summary>
        /// Create GET Request
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates an appRole
        /// param - new AppRole that is getting created
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Create(AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                _appRoleRepo.Create(appRole);
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        /// <summary>
        /// Shows App Role details
        /// param - id of the app role that you are wanting details for
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Details(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        /// <summary>
        /// Edit app roll GET request
        /// param - id of app role needed to be edited
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Edit(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        /// <summary>
        /// Edit app roll POST request
        /// param - updated AppRole that is getting edited
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Edit(AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                _appRoleRepo.Update(appRole.Id, appRole);
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        /// <summary>
        /// Delete app roll GET request
        /// param - id of app role to delete
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Delete(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        /// <summary>
        /// Delete app roll POST request
        /// param - id of app role to delete
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _appRoleRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
