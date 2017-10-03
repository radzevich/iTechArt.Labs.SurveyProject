using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly IUnitOfWork _database;

        private const string RegistrationSuccedMessageText = "Registration completed successfully";
        private const string UserIsAlreadyExistMessageText = "User with this email already exists";

        private const string PropertyNameUndefined = "";
        private const string PropertyNameEmail = "Email";

        public IdentityUserService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<OperationDetails> CreateAsync(UserServiceModel userDataToCreate)
        {
            ApplicationUser user = await _database.UserManager.FindByEmailAsync(userDataToCreate.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = userDataToCreate.Email,
                    UserName = userDataToCreate.Email
                };

                var result = await _database.UserManager.CreateAsync(user, userDataToCreate.Password);
                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), PropertyNameUndefined);

                var role = new ApplicationRole(userDataToCreate.Role);

                await _database.RoleManager.CreateAsync(role);
                await _database.UserManager.AddToRoleAsync(user.Id, userDataToCreate.Role);

                var clientProfile = new UserProfile
                {
                    Id = user.Id,
                    Name = userDataToCreate.Name
                };
                _database.UserProfileManager.Create(clientProfile);
                await _database.SaveAsync();

                return new OperationDetails(true, RegistrationSuccedMessageText, PropertyNameUndefined);
            }

            return new OperationDetails(false, UserIsAlreadyExistMessageText, PropertyNameEmail);
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(UserServiceModel userToAuthenticate)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _database.UserManager.FindAsync(userToAuthenticate.Email, userToAuthenticate.Password);
            if (user != null)
            {
                claim = await _database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public string GetUserId()
        {
            //_database.UserManager
            return null;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}