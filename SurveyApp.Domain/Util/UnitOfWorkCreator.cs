using SurveyApp.DAL.Interfaces;
using SurveyApp.DAL.Repositories;

namespace SurveyApp.Domain.Util
{
    public class UnitOfWorkCreator
    {
        private static IUnitOfWork _instance;

        public UnitOfWorkCreator(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new UnitOfWork(connectionString);
            }
        }

        public IUnitOfWork getInstance()
        {
            return _instance;
        }
    }
}