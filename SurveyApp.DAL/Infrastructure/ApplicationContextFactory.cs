using System.Data.Entity.Infrastructure;
using SurveyApp.DAL.DataContext;

namespace SurveyApp.DAL.Infrastructure
{
    public class ApplicationContextFactory : IDbContextFactory<ApplicationContext>
    {
        public ApplicationContext Create()
        {
            return new ApplicationContext("SurveyContext");
        }
    }
}