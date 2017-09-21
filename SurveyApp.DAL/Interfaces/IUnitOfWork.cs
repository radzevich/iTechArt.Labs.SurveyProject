using System;
using System.Threading.Tasks;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Identity;

namespace SurveyApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IUserProfileManager UserProfileManager { get; }

        IRepository<Survey> Surveys { get; }
        IRepository<CompletedSurvey> CompletedSurveys { get; }
        IRepository<Question> Questions { get; }
        IRepository<Page> Pages { get; }
        IRepository<AnswerOption> AnswerOptions { get; }
        IRepository<ReceivedAnswer> ReceivedAnswers { get; }

        void Save();
        Task SaveAsync();
    }
}
