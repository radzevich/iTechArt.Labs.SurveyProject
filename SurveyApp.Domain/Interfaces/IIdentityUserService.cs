using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserModel userDataToRegister);
        Task<ClaimsIdentity> AuthenticateAsync(UserModel userDataToAuthenticate);
    }
}