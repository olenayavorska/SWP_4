﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SWP_4.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace SWP_4.Controllers
{
    public class AccountController : Controller
    {
       
            private ApplicationContext _context;
            public AccountController(ApplicationContext context)
            {
                _context = context;
            }
            //SignalR testing
            public IActionResult Index()
            {
                return View();
            }
             
        [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = await _context.Users
                        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                    if (user != null)
                    {
                        await Authenticate(user); // autentification
                        return RedirectToAction("Index", "Account");// redirection to index method
                    }
                    ModelState.AddModelError("", "Login/password is incorrect");
                }
                return View(model);
            }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupModel model)//registration
        {
            if (ModelState.IsValid)
            {
                {
                    User user1 = new User { Email = model.Email, Password = model.Password };

                    await _context.Users.AddAsync(user1);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("Login", "Account");
                }
              

                //ModelState.AddModelError("", "fill all fields");
                
            }


            return View(model);
        }

        

        public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }
       
         


        private async Task Authenticate(User user)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
               
            };
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
        }
       
}
    

