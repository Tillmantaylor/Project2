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
using TVTProject2.Models;

namespace TVTProject2.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly IAppRoleRepository _appRoleRepo;
        private readonly IProjectRoleRepository _projectRoleRepository;

        /// <summary>
        /// Injects Repositories
        /// </summary>
        public PersonController(
            IProjectRepository projectRepo,
            IPersonRepository personRepo,
            IProjectRoleRepository projectRoleRepo,
            IAppRoleRepository appRoleRepo)
        {
            _personRepo = personRepo;
            _projectRepo = projectRepo;
            _appRoleRepo = appRoleRepo;
            _projectRoleRepository = projectRoleRepo;
        }

        /// <summary>
        /// Index view that shows People
        /// </summary>
        public IActionResult Index()
        {
            var allPeople = _personRepo.ReadAll();
            var model = allPeople.Select(p =>
            new PersonDetailsVM
            {
                Id = p.Id,
                FirstName = p.FirstName,
                MiddleName = p.MiddleName,
                Lastname = p.Lastname,
                Email = p.Email
            });
            return View(model);
        }

        /// <summary>
        /// Create GET request
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a person
        /// param - Person holding information being added
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Create(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        /// <summary>
        /// Shows Details of a person
        /// param - id of person
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Details(int id)
        {
            var person = _personRepo.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        /// <summary>
        /// Edit GET request
        /// param - id of person you want to edit
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Edit(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        /// <summary>
        /// Updates person with new information
        /// param - Person holding the new changes
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Update(person.Id, person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        /// <summary>
        /// Deletes person
        /// param - id of person that is getting deleted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public IActionResult Delete(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        /// <summary>
        /// Removes person from database
        /// param - id of person being deleted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personRepo.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Assign a person a role to a project
        /// params - AssignRole with information needed for assigning role
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public IActionResult AssignRole(AssignRole body)
        {
            var appRole = _appRoleRepo.ReadByName(body.Role);
            var person = _personRepo.Read(body.PersonId);
            var project = _projectRepo.Read(body.ProjectId);

            var projectRole = new ProjectRole
            {
                HourlyRate = body.HourlyRate,
                ProjectId = body.ProjectId,
                PersonId = body.PersonId,
                AppRoleId = appRole.Id
            };

            person.ProjectRoles.Add(projectRole);
            project.ProjectRoles.Add(projectRole);

            _projectRoleRepository.Create(projectRole);
            _personRepo.Update(body.PersonId, person);
            _projectRepo.Update(body.ProjectId, project);

            return RedirectToAction("Details", "Project", new { id = body.ProjectId });
        }

        /// <summary>
        /// Assign Role to a person
        /// params - projectId a project that is being worked with personId a person you are wanting to assign role to
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> AssignRole(int projectId, int personId)
        {
            var project = _projectRepo.Read(projectId);
            var person = _personRepo.Read(personId);
            var appRoles = _appRoleRepo.ReadAll();
            var projectRoles = (await _projectRoleRepository.ReadAllByProjectIdAsync(projectId)).Where(projRole => projRole.PersonId == personId).ToList();

            IEnumerable<AssignRoleOptions> assignRoleOptions = appRoles.Where(appRole => !projectRoles.Select(projRole => projRole.AppRoleId).Contains(appRole.Id)).Select(appRole => new AssignRoleOptions
            {
                Name = appRole.Name
            }).ToList();

            var assignRoleVM = new AssignRoleVM
            {
                ProjectId = projectId,
                ProjectName = project.Name,
                PersonName = $"{person.FirstName} {person.MiddleName} {person.Lastname}",
                AssignRoleOptions = assignRoleOptions,
                PersonId = personId
            };

            return View(assignRoleVM);
        }

        /// <summary>
        /// Removes a role from a person on a specific project
        /// params - projectId a project that is being worked with personId a person you are wanting to remove a role from
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        public async Task<IActionResult> RemoveRole(int projectId, int personId)
        {
            var project = await _projectRepo.ReadAsync(projectId);
            var person = _personRepo.Read(personId);
            var projectRoles = await _projectRoleRepository.ReadAllByProjectIdAndPersonIdAsync(projectId, personId);

            if (project == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (person == null)
            {
                return RedirectToAction("Details", "Project", new { id = projectId });
            }

            IEnumerable<string> roles = projectRoles.Select(role => _appRoleRepo.Read(role.AppRoleId).Name).ToList();

            var removePersonVM = new RemoveRoleVM
            {
                PersonId = personId,
                ProjectId = projectId,
                PersonName = $"{person.FirstName} {person.MiddleName} {person.Lastname}",
                ProjectName = project.Name,
                Roles = roles
            };

            return View(removePersonVM);
        }

        /// <summary>
        /// Removes role from person in database
        /// param - RemoveRole holding information needing to be deleted
        /// </summary>
        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public async Task<IActionResult> RemoveRole(RemoveRole body)
        {
            var appRole = _appRoleRepo.ReadByName(body.RoleName);
            var projectRole = (await _projectRoleRepository.ReadAllByProjectIdAndPersonIdAsync(body.ProjectId, body.PersonId)).First(role => role.AppRoleId == appRole.Id);
            _projectRoleRepository.Delete(projectRole.Id);

            return RedirectToAction("Details", "Project", new { id = body.ProjectId });
        }

        /// <summary>
        /// Person report
        /// </summary>
        public async Task<IActionResult> Report()
        {
            var peopleAll = _personRepo.ReadAll();

            ICollection<PersonReportPersonMetadata> people = new List<PersonReportPersonMetadata>();

            foreach (var person in peopleAll)
            {
                var projRoles = await _projectRoleRepository.ReadAllByPersonIdAsync(person.Id);

                IEnumerable<PersonReportProjectMetadata> projects = projRoles.Select(projectRole => new PersonReportProjectMetadata
                {
                    Name = _projectRepo.Read(projectRole.ProjectId).Name,
                    HourlyRate = projectRole.HourlyRate,
                    Role = _appRoleRepo.Read(projectRole.AppRoleId).Name
                }).ToList();

                decimal totalHourlyRate = HourlyRateSum(projects.Select(project => project.HourlyRate));

                var metadata = new PersonReportPersonMetadata
                {
                    Name = $"{person.FirstName} {person.MiddleName} {person.Lastname}",
                    Projects = projects,
                    HourlyRate = totalHourlyRate
                };

                people.Add(metadata);
            }

            var personReportVM = new PersonReportVM
            {
                people = people
            };

            return View(personReportVM);
        }

        /// <summary>
        /// Total the hourly rate
        /// </summary>
        private decimal HourlyRateSum(IEnumerable<decimal> rates)
        {
            decimal total = 0;
            foreach (var rate in rates)
            {
                total = total + rate;
            }

            return total;
        }
    }
}
