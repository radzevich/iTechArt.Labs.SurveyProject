using System;
using SurveyApp.Infrastructure.EntityModels;

namespace SurveyApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Survey> Surveys { get; }
        IRepository<CompletedSurvey> CompletedSurveys { get; }
        IRepository<Question> Questions { get; }
        IRepository<Page> Pages { get; }
        IRepository<AnswerOption> AnswerOptions { get; }
        IRepository<ReceivedAnswer> ReceivedAnswers { get; }

        void Save();
    }
}
