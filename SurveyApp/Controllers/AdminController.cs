using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
    //    private ApplicationUserManager _userManager;

    //    public AdminController()
    //    {
    //    }

    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }

    //    // GET: /Admin       
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    // GET: /Admin/Users
    //    [HttpGet]
    //    public ActionResult Users()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    public ActionResult EditUser(string userId)
    //    {
    //        var user = UserManager.Users.SingleOrDefault(u => u.Id.Equals(userId));
    //        var roleManager = new RoleManager<>()
    //        user.Roles.FirstOrDefault()

    //        if (user != null)
    //        {
    //            var model = new EditModel()
    //            {
    //                Name = user.Name,
    //                Email = user.Email,
    //                Role = user.Roles.FirstOrDefault().
    //            }
    //        }
    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult EditUser(EditModel model)
    //    {
    //        return View();
    //    }

    //    public ActionResult DeleteUser(DeleteModel model)
    //    {
    //        return View();
    //    }
    }
}