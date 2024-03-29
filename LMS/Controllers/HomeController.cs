﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LMS.Models;
using LMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserLogin()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult UserConfig()
        {
            return View();
        }
        public IActionResult CourseType()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Subjects()
        {
            return View();
        }
        public IActionResult Lecture()
        {
            return View();
        }
        public IActionResult LectureSubjects()
        {
            return View();
        }
        public IActionResult Modules()
        {
            return View();
        }
        

        [HttpPost]
        public string GetUserRS(string userName, string password)
        {
            using (var _context = new LMSDbContext())
            {
                UserMaster userMaster = new UserMaster();
                userMaster = _context.UserMasters.Where(m => m.UserName == userName && m.Password == password).FirstOrDefault();
                if (userMaster == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return "False"; 
                }
                else
                {
                    //HttpContext.Session.SetString("UserName", userMaster.UserName);
                    return userMaster.UserName.ToString();
                }
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserMaster model)
        {
            if (ModelState.IsValid)
            {
                //var VarUserMaster = await _context.UserMasters 
                //                                                                                                                                                                                c
                //.SingleOrDefaultAsync(m => m.UserName == model.UserName && m.Password == model.Password);
                //if (VarUserMaster == null)
                //{
                //    ModelState.AddModelError("Password", "Invalid login attempt.");
                //    return View("Login");
                //}
                //HttpContext.Session.SetString("userId", VarUserMaster.UserName);

            }
            else
            {
                return View("Login");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }


        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        }*/
    }
}
