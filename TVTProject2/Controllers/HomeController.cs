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
using Microsoft.AspNetCore.Identity;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUserRepository _userRepo;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Injects Repositories
        /// </summary>
        public HomeController(
            ILogger<HomeController> logger, 
            IApplicationUserRepository userRepo, 
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userRepo = userRepo;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Index view that signs in Proman
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync("Proman");

            var result = await _signInManager.PasswordSignInAsync(user, "Admin1!", false, false);

            return View();
        }

        /// <summary>
        /// Privacy
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error View
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Gets a users id
        /// </summary>
        public int GetUserId()
        {
            return _userRepo.ReadAsync(User.Identity.Name).Id;

        }
    }
}
