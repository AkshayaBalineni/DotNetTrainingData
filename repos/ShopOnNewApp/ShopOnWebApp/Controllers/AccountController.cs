using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopOnWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //userManager => manage user(Register)
        //singIn manager=> login/logout
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {

            if (ReturnUrl == null)
            {
                ViewBag.currentUrl = 1;
                return View();
            }
            ViewBag.currentUrl = ReturnUrl;
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin user,string ReturnUrl)
        {
            if(ModelState.IsValid)
            { 
                var result = await signInManager.PasswordSignInAsync(user.LoginId, user.Password,user.RemeberMe,false);
                if(result.Succeeded)
                {
                    if(!(string.Equals(ReturnUrl,"1")))
                    {
                        string[] arr = ReturnUrl.Split('/');
                        return RedirectToAction(arr[2], arr[1]);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
           
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM newUser)
        {
           if( ModelState.IsValid)
            {
                //create IdentityUser
                var user = new IdentityUser() { UserName = newUser.LoginId, Email = newUser.LoginId };
                var result = await userManager.CreateAsync(user, newUser.Password);
                //User manager => Register
                if(result.Succeeded)
                {
                    //conside user as login user
                   await signInManager.SignInAsync(user, isPersistent: false);
                    //redirect to home page
                    return RedirectToAction("Index", "Home");
                }
                //Handling errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
               
            }
            return View(newUser);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
