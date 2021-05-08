using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using BusTicket.Models;
using BusTicket.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace BusTicket.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            user.LastUpdateDate = DateTime.Now;
            user.CreateDate = DateTime.Now;
            _db.User.Add(user);
            _db.SaveChanges();
            return RedirectToAction("SingIn");
        }

        [HttpGet]
        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn(User user)
        {
            var loginUser = _db.User.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if(loginUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var userIdentitiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentitiy);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("BuyTicket","Home");
            }
            return View();
        }



    }
}
