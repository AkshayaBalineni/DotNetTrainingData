using BankingBussinessLayer.cs.Contracts;
using BankingCommonLayer.Models;
using BankingWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnWebApp.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginManager loginManager;

        public HomeController(ILogger<HomeController> logger,ILoginManager loginManager)
        {
            _logger = logger;
            this.loginManager = loginManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MangerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MangerLogin(ManagerLogin manager)
        {
            if (ModelState.IsValid)
            {
                Manager newManager = new Manager()
                {
                    ManagerId = manager.MangerId,
                    ManagerPassword = manager.Password
                };
                bool isvalid = loginManager.ValidateManager(newManager);
                if (isvalid)
                {
                    HttpContext.Session.SetSession("manager", newManager);
                    HttpContext.Session.SetString("managerId", manager.MangerId);
                    return RedirectToAction("ManagerFeatures");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
            return View();
        }

        public IActionResult ManagerFeatures()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult SuccessAdd()
        {
            ViewBag.msg = TempData["SuccessMessage"];
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                Manager manager = new Manager()
                {
                    ManagerId = changePassword.ManagerId,
                    ManagerPassword = changePassword.NewPassword
                };
                bool isupdated = this.loginManager.ChangePassword(manager);
                if (isupdated)
                {
                    return RedirectToAction("Logout");
                }
                ModelState.AddModelError("", "Try Again!");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
