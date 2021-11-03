using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TVTProject2.Models;
using TVTProject2.Services;

namespace TVTProject2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUserRepository _userRepo;

        public HomeController(ILogger<HomeController> logger, IApplicationUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetUserId()
        {
            var user = await _userRepo.ReadAsync(User.Identity.Name);
            return Content(user.Id);
        }
      
        public async Task<IActionResult> AssignUserToRole()
        {
            await _userRepo.AssignUserToRoleAsync("guard@gmail.com", "ProjectManager");
            return Content("Assigned 'guard@gmail.com' to role ProjectManager");
        }       
    }
}
