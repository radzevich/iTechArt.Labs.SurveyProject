using System;
using SurveyApp.Infrastructure.DataContext;
using SurveyApp.Infrastructure.EntityModels;
using SurveyApp.Infrastructure.Interfaces;

namespace SurveyApp.Infrastructure.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyContext _context;

        public IRepository<User> Users { get; }
        public IRepository<Survey> Surveys { get; }
        public IRepository<CompletedSurvey> CompletedSurveys { get; }
        public IRepository<Question> Questions { get; }
        public IRepository<Page> Pages { get; }
        public IRepository<AnswerOption> AnswerOptions { get; }
        public IRepository<ReceivedAnswer> ReceivedAnswers { get; }

        public UnitOfWork()
        {
            _context = new SurveyContext();

            Users = new Repository<User>(_context);
            Surveys = new Repository<Survey>(_context);
            CompletedSurveys = new Repository<CompletedSurvey>(_context);
            Questions = new Repository<Question>(_context);
            Pages = new Repository<Page>(_context);
            AnswerOptions = new Repository<AnswerOption>(_context);
            ReceivedAnswers = new Repository<ReceivedAnswer>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
