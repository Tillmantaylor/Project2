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
        public ProjectRoleController(IProjectRoleRepository projectRoleRepo)
        {
            _projectRoleRepo = projectRoleRepo;
        }
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
