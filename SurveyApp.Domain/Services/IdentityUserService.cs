using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;
using SurveyApp.Domain.Infrastructure;
using SurveyApp.Domain.Interfaces;
using SurveyApp.Domain.Models;
using SurveyApp.Domain.Util;

namespace SurveyApp.Domain.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly IUnitOfWork _database;

        private const string RegistrationSuccedMessageText = "Регистрация успешно пройдена";
        private const string UserIsAlreadyExistMessageText = "Пользователь с таким логином уже существует";

        private const string PropertyNameUndefined = "";
        private const string PropertyNameEmail = "Email";

        public IdentityUserService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<OperationDetails> Create(User userDataToCreate)
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
            else
            {
                return new OperationDetails(false, UserIsAlreadyExistMessageText, PropertyNameEmail);
            }
        }

        public async Task<ClaimsIdentity> Authenticate(User userToAuthenticate)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _database.UserManager.FindAsync(userToAuthenticate.Email, userToAuthenticate.Password);
            if (user != null)
            {
                claim = await _database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}