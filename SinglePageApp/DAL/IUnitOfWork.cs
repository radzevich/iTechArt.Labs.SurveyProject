using System;
using SinglePageApp.Models;

namespace SinglePageApp.DAL
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
