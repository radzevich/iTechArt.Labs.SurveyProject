using Microsoft.AspNet.Identity;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Util;
using SurveyApp.DAL.Repositories;

namespace SurveyApp.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public virtual IIdentityUserService CreateIdentityUserService(string connectionString)
        {
            //var unitOfWorkCreator = new UnitOfWorkCreator(connectionString);
            //return new IdentityUserService(unitOfWorkCreator.getInstance());
            return new IdentityUserService(new UnitOfWork(connectionString));
        }

        public virtual ISurveyService CreateSurveyService(string connectionString)
        {
            return new SurveyService(new UnitOfWork(connectionString));
        }
    }
}