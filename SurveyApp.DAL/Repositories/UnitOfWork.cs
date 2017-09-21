using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Identity;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        #region Repositories

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IUserProfileManager _userProfileManager { get; }
        private IRepository<Survey> _surveys { get; }
        private IRepository<CompletedSurvey> _completedSurveys { get; }
        private IRepository<Question> _questions { get; }
        private IRepository<Page> _pages { get; }
        private IRepository<AnswerOption> _answerOptions { get; }
        private IRepository<ReceivedAnswer> _receivedAnswers { get; }

        #endregion

        public UnitOfWork()
        {
            _context = new ApplicationContext();

            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));

            _userProfileManager = new UserProfileManager(_context);

            _surveys = new Repository<Survey>(_context);
            _completedSurveys = new Repository<CompletedSurvey>(_context);
            _questions = new Repository<Question>(_context);
            _pages = new Repository<Page>(_context);
            _answerOptions = new Repository<AnswerOption>(_context);
            _receivedAnswers = new Repository<ReceivedAnswer>(_context);
        }

        #region RepositoryGetters

        public ApplicationUserManager UserManager => _userManager;

        public ApplicationRoleManager RoleManager => _roleManager;

        public IUserProfileManager UserProfileManager => _userProfileManager;

        public IRepository<Survey> Surveys => _surveys;

        public IRepository<CompletedSurvey> CompletedSurveys => _completedSurveys;

        public IRepository<Question> Questions => _questions;

        public IRepository<Page> Pages => _pages;

        public IRepository<AnswerOption> AnswerOptions => _answerOptions;

        public IRepository<ReceivedAnswer> ReceivedAnswers => _receivedAnswers;

        #endregion


        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
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
