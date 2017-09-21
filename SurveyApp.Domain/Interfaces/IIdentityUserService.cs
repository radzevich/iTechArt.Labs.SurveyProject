using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SurveyApp.Domain.Infrastructure;
using SurveyApp.Domain.Models;

namespace SurveyApp.Domain.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        Task<OperationDetails> Create(User userDto);
        Task<ClaimsIdentity> Authenticate(User user);
    }
}