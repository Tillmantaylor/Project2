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
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;
        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        
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
 
        [Authorize(Roles = "ProjectManager")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "ProjectManager")]
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
     
        [Authorize(Roles = "ProjectManager")]
        public IActionResult Details(int id)
        {
            var person = _personRepo.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Edit(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [Authorize(Roles = "ProjectManager")]
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

        [Authorize(Roles = "ProjectManager")]
        public IActionResult Delete(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [Authorize(Roles = "ProjectManager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
