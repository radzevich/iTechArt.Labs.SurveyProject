using System;
using System.Threading.Tasks;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Identity;
using SurveyApp.DAL.Repositories;

namespace SurveyApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserProfileManager UserProfileManager { get; }

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        SurveyRepository Surveys { get; }
        IRepository<CompletedSurvey> CompletedSurveys { get; }

        IRepository<PageDataModel> Pages { get; }
        IRepository<QuestionDataModel> Questions { get; }
        IRepository<AnswerDataModel> Answers { get; }

        void Save();
        Task SaveAsync();
    }
}
