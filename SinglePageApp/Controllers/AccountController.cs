using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SinglePageApp.DAL;
using SinglePageApp.Models;
using SinglePageApp.Providers;

namespace SinglePageApp.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var unitOfWork = UnitOfWorkSingleton.Instance();

            return View(unitOfWork.Users.Get());
        }

        public ActionResult Register()
        {
            if (Session["AuthenticationHash"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // TODO: do not save Login and Password in explicit way, use hash with salt.
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                var unitOfWork = UnitOfWorkSingleton.Instance();
                var toHashEncryptor = new Encryptor();

                var user = new User
                {
                    Name = account.Name,
                    Email = account.Email,
                    PasswordHash = toHashEncryptor.Encrypt(account.Password)
                };

                unitOfWork.Users.Insert(user);
                unitOfWork.Save();

                ModelState.Clear();
            }

            return View();
        }

        public ActionResult Login()
        {
            if (Session["AuthenticationHash"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount account)
        {
            var toHashEncryptor = new Encryptor();
            var userTryingToLogin = new User
            {
                Email = account.Email,
                PasswordHash = toHashEncryptor.Encrypt(account.Password)
            };

            var unitOfWork = UnitOfWorkSingleton.Instance();
            var existingUser = unitOfWork.Users.Get(filter: u => u.Email == userTryingToLogin.Email &&
                                                                 u.PasswordHash == userTryingToLogin.PasswordHash)
                                               ?.SingleOrDefault();
            if (existingUser != null)
            {
                Session["UserName"] = existingUser.Name;
                Session["AuthenticationHash"] = toHashEncryptor.Encrypt(existingUser.Name + existingUser.PasswordHash);

                if (existingUser.Status == "admin")
                {
                    Session["UserStatus"] = "admin";
                }

                return RedirectToAction("LoggedIn");
            }

            ModelState.AddModelError("", "Неверный логин или пароль");

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoggedIn()
        {
            if (Session["AuthenticationHash"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}