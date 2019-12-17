﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CBelt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace CBelt.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context){
            DbContext = context;
        } 
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("user/new")]
        public IActionResult registration(User newUser){
            if(ModelState.IsValid){
                if(DbContext.Users.Any(user => user.Email == newUser.Email)){
                    ModelState.AddModelError("Email", "Not Today");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                DbContext.Add(newUser);
                DbContext.SaveChanges();
                HttpContext.Session.SetInt32("userId", newUser.UserId);
                return RedirectToAction("All", "Activ");
            }
            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpPost("user/login")]
        public IActionResult Login(Login userlog){
            if(ModelState.IsValid){
                var userInDb = DbContext.Users.FirstOrDefault(user => user.Email == userlog.LoginEmail);
                if(userInDb == null){
                    ModelState.AddModelError("LoginEmail", "Not today");
                    return View("Index");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(userlog, userInDb.Password, userlog.LoginPassword);
                if(result==0){
                    ModelState.AddModelError("LoginEmail", "Not today");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("All", "Activ");
            } else{
                return View("Index");
            }
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
    }
}
