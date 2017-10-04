using System;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Repositories.Interfaces
{
    public interface IUserProfileManager : IDisposable
    {
        void Create(UserProfile item);
    }
}