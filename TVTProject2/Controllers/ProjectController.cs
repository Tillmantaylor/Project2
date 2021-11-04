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
        public ProjectController(
            IProjectRepository projectRepo, 
            IPersonRepository personRepo, 
            IProjectRoleRepository projectroleRepo, 
            IApplicationUserRepository userRepo,
            IAppRoleRepository appRoleRepo)
        {
            _projectRepo = projectRepo;
            _personRepo = personRepo;
            _projectRoleRepository = projectroleRepo;
            _userRepo = userRepo;
            _appRoleRepo = appRoleRepo;
        }

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

        [Authorize(Roles = "Project Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [Authorize(Roles = "Project Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectRepo.Delete(id);
            return RedirectToAction("Index");
        }

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

        [Authorize(Roles="Project Manager")]
        public async Task<IActionResult> AssignRole(int projectId, int personId)
        {
            var project = _projectRepo.Read(projectId);
            var person = _personRepo.Read(personId);
            var appRoles = _appRoleRepo.ReadAll();
            var projectRoles = (await _projectRoleRepository.ReadAllByProjectIdAsync(projectId)).Where(projRole => projRole.PersonId == personId).ToList();

            IEnumerable<AssignRoleOptions> assignRoleOptions = appRoles.Where(appRole => !projectRoles.Select(projRole => projRole.AppRoleId).Contains(appRole.Id)).Select(appRole => new AssignRoleOptions {
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

            return RedirectToAction("Details", new { id = body.ProjectId });
        }

        [Authorize(Roles = "Project Manager")]
        public IActionResult Report()
        {
            ViewData["Message"] = "Projeect Report";
            var project = _projectRepo.ReadAll();
            var person = _personRepo.ReadAll();

            return View();
        }
    }
}
