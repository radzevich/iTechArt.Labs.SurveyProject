using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SurveyApp.DAL.EntityModels;
using SurveyApp.BLL.Models;


namespace SurveyApp.BLL.Validators
{
    public class CustomUserValidator : IIdentityValidator<User>
    {
        private readonly Regex _emailRegex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly UserManager<ApplicationUser> _manager;

        public CustomUserValidator()
        {
        }

        public CustomUserValidator(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        public async Task<IdentityResult> ValidateAsync(User item)
        {
            var errors = new List<string>();
            if (!_emailRegex.IsMatch(item.Email))
                errors.Add("Неверный e-mail.");

            if (_manager != null)
            {
                var otherAccount = await _manager.FindByEmailAsync(item.Email);
                if (otherAccount != null && otherAccount.Id != item.Id)
                    errors.Add("Пользователь с таким e-mail уже зарегистрирован на сайте.");
            }

            return IdentityResult.Success;
            //return errors.Any()
            //    ? IdentityResult.Failed(errors.ToArray())
            //    : IdentityResult.Success;
        }
    }
}