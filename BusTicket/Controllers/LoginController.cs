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
using BusTicket.Models.ViewModels;

namespace BusTicket.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            user.LastUpdateDate = DateTime.Now;
            user.CreateDate = DateTime.Now;
            var registeredUser = _db.User.SingleOrDefault(x => x.Email == user.Email);
            if (registeredUser == null)
            {
                _db.User.Add(user);
                _db.SaveChanges();
                return RedirectToAction("SingIn");
            }
            else
            {
                ModelState.AddModelError(String.Empty,"Zaten üyesiniz");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SingIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn(SingInModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("SingIn");
            }
            var loginUser = _db.User.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (loginUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email)
                };
                var userIdentitiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentitiy);

                await HttpContext.SignInAsync(principal);

                if (loginUser.IsAdmin)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("BuyTicket", "Home");
                }
            }

            else
            {
                ModelState.AddModelError(String.Empty, "Şifre veya kullanıcı hatalıdır");
            }

            return View();
        }
    }
}
