using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Repositories.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class SurveyRepository : Repository<SurveyDataModel>, ISurveyRepository
    {

        public SurveyRepository(ApplicationContext context) : base(context)
        {
        }

        public async void CreateAsync(SurveyDataModel surveyToCreate)
        {
            context.Surveys.Add(surveyToCreate);
            await context.SaveChangesAsync();
        }

        public IEnumerable<SurveyDataModel> GetSurveysByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId == creatorId);
        }
    }
}