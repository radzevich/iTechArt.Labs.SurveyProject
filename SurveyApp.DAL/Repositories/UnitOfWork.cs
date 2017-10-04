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
        private const string ConnectionString = "SurveyContext";

        private readonly ApplicationContext _context;

        public UnitOfWork()
        {
            _context = new ApplicationContext(ConnectionString);

            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
            UserProfileManager = new UserProfileManager(_context);

            Surveys = new SurveyRepository(_context);
            SurveyTemplates = new SurveyTemplateRepository(_context);
            CompletedSurveys = new Repository<CompletedSurvey>(_context);
            Pages = new Repository<PageDataModel>(_context);
            Questions = new Repository<QuestionDataModel>(_context);
            Answers = new Repository<AnswerDataModel>(_context);
        }

        #region RepositoryGetters

        public ApplicationUserManager UserManager { get; }

        public ApplicationRoleManager RoleManager { get; }

        public IUserProfileManager UserProfileManager { get; }

        public SurveyRepository Surveys { get; }

        public SurveyTemplateRepository SurveyTemplates { get; set; }

        public IRepository<CompletedSurvey> CompletedSurveys { get; }

        public IRepository<PageDataModel> Pages { get; }

        public IRepository<QuestionDataModel> Questions { get; }

        public IRepository<AnswerDataModel> Answers { get; }

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
