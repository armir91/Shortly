﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortly.Client.Data.ViewModels;
using Shortly.Data;

namespace Shortly.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Users()
        {
            var users = _context
                .Users
                .Include(url => url.Urls)
                .ToList();
            return View(users);
        }

        public IActionResult Login()
        {
            var initial = new LoginVM();

            return View(initial);
        }

        public IActionResult LoginSubmitted(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View("Login", loginVM);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        public IActionResult RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View("Register", registerVM);

            return RedirectToAction("Index", "Home");
        }
    }
}
