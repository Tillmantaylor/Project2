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
using TVTProject2.Controllers;
using TVTProject2.Models;

namespace TVTProject2.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IProjectRoleRepository _projectRoleRepository;
        private readonly IApplicationUserRepository _userRepo;
        private readonly IAppRoleRepository _appRoleRepo;

        /// <summary>
        /// Injects repositories
        /// </summary>
        public ProjectController(
            IProjectRepository projectRepo, 
            IPersonRepository personRepo, 
            IProjectRoleRepository projectRoleRepo, 
            IApplicationUserRepository userRepo,
            IAppRoleRepository appRoleRepo)
        {
            _projectRepo = projectRepo;
            _personRepo = personRepo;
            _projectRoleRepository = projectRoleRepo;
            _userRepo = userRepo;
            _appRoleRepo = appRoleRepo;
        }

        /// <summary>
        /// Basic information about projects
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Index()
        {
            var allProjects = _projectRepo.ReadAll();
            var model = allProjects.Select(p =>
            new ProjectDetailsVM
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = p.StartDate,
                DueDate = p.DueDate
            });
            return View(model);
        }

        /// <summary>
        /// Create GET request
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a project
        /// param - Project information needed for creation
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepo.Create(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        /// <summary>
        /// Shows details of project
        /// param - id of project that details are wanted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectRepo.ReadAsync(id);
            var projectRoles = await _projectRoleRepository.ReadAllByProjectIdAsync(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }

            IEnumerable<PersonRole> people = projectRoles.AsEnumerable().GroupBy(projectRole => projectRole.PersonId).Select(projectRole => new PersonRole
            {
                Name = $"{_personRepo.Read(projectRole.Key).FirstName} {_personRepo.Read(projectRole.Key).MiddleName} {_personRepo.Read(projectRole.Key).Lastname}",
                projectRoles = projectRoles.Where(projRole => projRole.PersonId == projectRole.Key).GroupBy(projRole => projRole.AppRoleId).Select(p => _appRoleRepo.Read(p.Key).Name).ToList(),
                PersonId = projectRole.Key,
                ProjectId = id,
            }).ToList();

            var projectDetailsVM = new ProjectDetailsVM
            {
                Name = project.Name,
                Count = projectRoles.GroupBy(projectRole => projectRole.PersonId).Count(),
                StartDate = project.StartDate,
                DueDate = project.DueDate,
                ProjectDue = project.DueDate.Subtract(project.StartDate).Days,
                People = people,
                ProjectId = id,
            };

            return View(projectDetailsVM);
        }

        /// <summary>
        /// Edit project
        /// param - id of project wanted to be edited
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Edit(int id)
        {
            var project = _projectRepo.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        /// <summary>
        /// Editing changes made to database
        /// param - Project holding editted changes
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepo.Update(project.Id, project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        /// <summary>
        /// Deletes project
        /// param - id of project wanting to be deleted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Delete(int id)
        {
            var project = _projectRepo.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        /// <summary>
        /// Deletes project from database
        /// param - id of project being deleted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectRepo.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Assign people to project
        /// param - id of project being added to
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Assign(int id)
        {
            var project = await _projectRepo.ReadAsync(id);
            var people = _personRepo.ReadAll();
            var projectRoles = await _projectRoleRepository.ReadAllByProjectIdAsync(project.Id);

            if (project == null)
            {
                return RedirectToAction("Index");
            }      
            var model = new AssignPersonVM
            {
                Name = project.Name,
                People = people.Where(person => !person.ProjectRoles.Any(projectRole => projectRole.ProjectId == project.Id)).ToList(),
                ProjectId = project.Id
            };
            return View(model);
        }

        /// <summary>
        /// Assigns person to project
        /// param - id of person to be added projectId of project being added to
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult AssignPerson(int id, int projectId)
        {
            var appRole = _appRoleRepo.ReadByName("Member");
            var person = _personRepo.Read(id);
            var project = _projectRepo.Read(projectId);

            var projectRole = new ProjectRole
            {
                PersonId = id,
                ProjectId = projectId,
                AppRoleId = appRole.Id,
            };

            person.ProjectRoles.Add(projectRole);
            project.ProjectRoles.Add(projectRole);

            _projectRoleRepository.Create(projectRole);
            _personRepo.Update(id, person);
            _projectRepo.Update(projectId, project);

            return RedirectToAction("Assign", new { id = projectId });
        }

        /// <summary>
        /// Removes person from project
        /// param - projectId project being removed from personId person being removed
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> RemovePerson(int projectId, int personId)
        {
            var project = await _projectRepo.ReadAsync(projectId);
            var projectRoles = await _projectRoleRepository.ReadAllByProjectIdAsync(projectId);
            var person = _personRepo.Read(personId);

            IEnumerable<PersonRole> people = projectRoles.AsEnumerable().GroupBy(projectRole => projectRole.PersonId).Select(projectRole => new PersonRole
            {
                Name = $"{_personRepo.Read(projectRole.Key).FirstName} {_personRepo.Read(projectRole.Key).MiddleName} {_personRepo.Read(projectRole.Key).Lastname}",
                projectRoles = projectRoles.Where(projRole => projRole.PersonId == projectRole.Key).GroupBy(projRole => projRole.AppRoleId).Select(p => _appRoleRepo.Read(p.Key).Name).ToList(),
                PersonId = projectRole.Key,
                ProjectId = personId,
            }).ToList();

            if (project == null)
            {
                return RedirectToAction("Index");
            }

            var RemovePersonVM = new RemovePersonVM
            {
                ProjectName = project.Name,
                ProjectId = projectId,
                PersonId = personId,
                Person = person,
                ProjectRoles = people.First(person => person.PersonId == personId).projectRoles.ToList()
            };
            return View(RemovePersonVM);
        }

        /// <summary>
        /// Database changes to remove person from project
        /// param - RemovePerson holding information of chnages needed to be made to database
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost, ActionName("RemovePerson")]
        public async Task<IActionResult> RemovePersonFromProject(RemovePerson body)
        {
            var projectRoles = await _projectRoleRepository.ReadAllByProjectIdAndPersonIdAsync(body.ProjectId, body.PersonId);

            foreach (ProjectRole projectRole in projectRoles)
            {
                _projectRoleRepository.Delete(projectRole.Id);
            }

            return RedirectToAction("Details", new { id = body.ProjectId });
        }

        /// <summary>
        /// Project Report
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> Report()
        {
            var projectAll = _projectRepo.ReadAll();

            ICollection<ProjectMetadata> projects = new List<ProjectMetadata>();

            foreach (var project in projectAll)
            {
                var projRoles = await _projectRoleRepository.ReadAllByProjectIdAsync(project.Id);

                IEnumerable<PersonMetadata> people = projRoles.Select(projectRole => new PersonMetadata
                {
                    Name = $"{_personRepo.Read(projectRole.PersonId).FirstName} {_personRepo.Read(projectRole.PersonId).MiddleName} {_personRepo.Read(projectRole.PersonId).Lastname}",
                    HourlyRate = projectRole.HourlyRate,
                    RoleName = _appRoleRepo.Read(projectRole.AppRoleId).Name
                }).ToList();

                decimal totalHourlyRate = HourlyRateSum(people.Select(person => person.HourlyRate));

                var metadata = new ProjectMetadata
                {
                    Name = project.Name,
                    People = people,
                    TotalHourlyRate = totalHourlyRate
                };

                projects.Add(metadata);
            }

            var projectReportVM = new ProjectReportVM
            {
                Projects = projects
            };

            return View(projectReportVM);
        }

        /// <summary>
        /// Total the hourly rate
        /// </summary>
        private decimal HourlyRateSum (IEnumerable<decimal> rates)
        {
            decimal total = 0;
            foreach(var rate in rates)
            {
                total = total + rate;
            }

            return total;
        }
    }
}
