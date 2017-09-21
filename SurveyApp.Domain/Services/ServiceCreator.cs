using SurveyApp.Domain.Interfaces;
using SurveyApp.Domain.Util;

namespace SurveyApp.Domain.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IIdentityUserService CreateIdentityUserService(string connectionString)
        {
            var unitOfWorkCreator = new UnitOfWorkCreator(connectionString);
            return new IdentityUserService(unitOfWorkCreator.getInstance());
        }
    }
}