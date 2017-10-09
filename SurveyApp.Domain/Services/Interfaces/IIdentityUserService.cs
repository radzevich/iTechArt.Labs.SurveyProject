using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Services.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserServiceModel userDataToRegister);
        Task<ClaimsIdentity> AuthenticateAsync(UserServiceModel userDataToAuthenticate);
        Task<bool> IsUserExists(string userToCheckId);
    }
}