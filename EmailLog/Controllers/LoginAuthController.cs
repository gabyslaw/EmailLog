using EmailLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EmailLog.Controllers
{
    [AllowAnonymous]
    public class LoginAuthController : Controller
    {
        [HttpGet]
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginInfo model, string returnUrl)
        {
            var Username = "gabyslaw@gmail.com";
            var Password = "admin";
            if (this.ModelState.IsValid && model.Username == Username && model.Password == Password)
            {
                model.Username = Username;
                model.Password = Password;
                ClaimsIdentity claims = new ClaimsIdentity("ApplicationCookie");
                claims.AddClaim(new Claim(ClaimTypes.Email, model.Username));
                var ctxt = this.Request.GetOwinContext();
                ctxt.Authentication.SignIn(claims);
               // return RedirectToAction("Index", "Home");
                return Redirect(GetRedirectUrl(returnUrl));
            }
            else
                 this.ModelState.AddModelError("", "Gerrout, Invalid Username and/or Password");
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}