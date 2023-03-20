using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SHABAEIKO_ORGANIC_FARM.Data;
using SHABAEIKO_ORGANIC_FARM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbcontext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserController(ApplicationDbcontext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }
   
        public IActionResult Index()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("login")]
        public ActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST-Login
        [HttpPost("login")]
        //[ValidateAntiForgeryToken
        public async Task<IActionResult> Login(User obj, string returnUrl)
        {
            returnUrl = "/";
            var row = _db.Users.Where(model => model.Email == obj.Email && model.Password == obj.Password).FirstOrDefault();
            if (row != null)
            {
                string userName = obj.Email;
                var claims = new List<Claim>
                {
                    new Claim("username", userName),
                    new Claim(ClaimTypes.NameIdentifier, userName),
                    new Claim(ClaimTypes.Name, "Sahara Malla")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Error. Username or Password is invalid";
            return View("Login");
        }
      
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");


        }
   
}
}

