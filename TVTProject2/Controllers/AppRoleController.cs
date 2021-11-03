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
        public AppRoleController(IAppRoleRepository appRoleRepo)
        {
            _appRoleRepo = appRoleRepo;
        }
        public IActionResult Index()
        {
            var model = _appRoleRepo.ReadAll();
            return View(model);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "ProjectManager")]
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

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Details(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Edit(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        [Authorize(Roles = "ProjectManager")]
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

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Delete(int id)
        {
            var appRole = _appRoleRepo.Read(id);
            if (appRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(appRole);
        }

        [Authorize(Roles = "ProjectManager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _appRoleRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
