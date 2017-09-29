using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class SurveyRepository : Repository<SurveyDataModel>, ISurveyRepository
    {

        public ApplicationContext Database { get; set; }

        public SurveyRepository(ApplicationContext context) : base(context)
        {
            Database = context;
        }

        public void Create(SurveyDataModel surveyToCreate)
        {
            context.Surveys.Add(surveyToCreate);
            context.SaveChanges();
        }
    }
}