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
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IProjectRoleRepository _projectRoleRepository;
        public ProjectController(IProjectRepository projectRepo, IPersonRepository personRepo, IProjectRoleRepository projectroleRepo)
        {
            _projectRepo = projectRepo;
            _personRepo = personRepo;
            _projectRoleRepository = projectroleRepo;
        }
        [Authorize(Roles = "ProjectManager")]
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
    
        [Authorize(Roles = "ProjectManager")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "ProjectManager")]
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

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Details(int id)
        {
            var project = _projectRepo.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Edit(int id)
        {
            var project = _projectRepo.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [Authorize(Roles = "ProjectManager")]
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

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Delete(int id)
        {
            var project = _projectRepo.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [Authorize(Roles = "ProjectManager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Assign(int id)
        {
            var project = _projectRepo.Read(id);
            var people = _personRepo.ReadAllProjId(project.Id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }      
            var model = new AssignPersonVM
            {
                Name = project.Name,
                People = people,
                ProjectId = project.Id
            };
            return View(model);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult AssignPerson(int id, int projectId)
        {
            var person = _personRepo.Read(id);
            var project = _projectRepo.Read(projectId);
            var projectRole = _projectRoleRepository.Read(project.Id);
            _personRepo.AddProjectRoles(projectRole, id);
            return RedirectToAction("Index");
        }    
      
        [Authorize(Roles = "ProjectManager")]
        public IActionResult Report()
        {
            ViewData["Message"] = "Projeect Report";
            var project = _projectRepo.ReadAll();
            var person = _personRepo.ReadAll();

            return View();
        }
    }
}
