using System.Collections.Generic;
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

        public void Create(SurveyDataModel surveyToCreate)
        {
            context.Surveys.Add(surveyToCreate);
            context.SaveChangesAsync();
        }

        public IEnumerable<SurveyDataModel> GetSurveysByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId == creatorId);
        }
    }
}