using System;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Interfaces
{
    public interface IUserProfileManager : IDisposable
    {
        void Create(UserProfile item);
    }
}