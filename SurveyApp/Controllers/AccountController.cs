﻿using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Services.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.Filters;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IIdentityUserService UserService { get; }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        [AllowCors]
        [AllowAnonymous]
        [Unauthenticated]
        public ActionResult GetCurrentUserName()
        {
            return Json(User.Identity.Name);
        }

        public AccountController(IIdentityUserService userService)
        {
            UserService = userService;
        }

        [Unauthenticated]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Unauthenticated]   
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userToLogin = new UserServiceModel { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.AuthenticateAsync(userToLogin);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [Unauthenticated]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Unauthenticated]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //AuthenticationManager.
            if (ModelState.IsValid)
            {
                var userToRegister = new UserServiceModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.CreateAsync(userToRegister);
                if (operationDetails.Succedeed)
                {
                    ClaimsIdentity claim = await UserService.AuthenticateAsync(userToRegister);
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }

}