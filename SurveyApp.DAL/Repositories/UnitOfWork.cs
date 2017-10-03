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

        #region Repositories

        private ApplicationUserManager _userManager { get; }
        private ApplicationRoleManager _roleManager { get; }
        private SurveyRepository _surveys { get; }
        private IUserProfileManager _userProfileManager { get; }
        private IRepository<CompletedSurvey> _completedSurveys { get; }

        #endregion

        public UnitOfWork()
        {
            _context = new ApplicationContext(ConnectionString);

            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));

            _userProfileManager = new UserProfileManager(_context);

            _surveys = new SurveyRepository(_context);
            _completedSurveys = new Repository<CompletedSurvey>(_context);
        }

        #region RepositoryGetters

        public ApplicationUserManager UserManager => _userManager;
        public ApplicationRoleManager RoleManager => _roleManager;
        public IUserProfileManager UserProfileManager => _userProfileManager;
        public SurveyRepository Surveys => _surveys;
        public IRepository<CompletedSurvey> CompletedSurveys => _completedSurveys;

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
