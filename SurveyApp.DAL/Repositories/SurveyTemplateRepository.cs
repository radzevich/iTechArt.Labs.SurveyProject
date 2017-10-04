using System.Collections.Generic;
using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Repositories.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class SurveyTemplateRepository : Repository<SurveyTemplateDataModel>, ISurveyTemplateRepository
    {
        public SurveyTemplateRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(SurveyTemplateDataModel surveyTemplateToCreate)
        {
            context.SurveyTemplates.Add(surveyTemplateToCreate);
            context.SaveChangesAsync();
        }

        public IEnumerable<SurveyTemplateDataModel> GetSurveyTemplatesByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId == creatorId);
        }
    }
}