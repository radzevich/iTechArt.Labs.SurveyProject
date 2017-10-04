using System.Collections.Generic;
using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class SurveyTemplateRepository : Repository<SurveyTemplateDataModel>, ISurveyTemplateRepository
    {
        public ApplicationContext Database { get; set; }

        public SurveyTemplateRepository(ApplicationContext context) : base(context)
        {
            Database = context;
        }

        public void Create(SurveyTemplateDataModel surveyTemplateToCreate)
        {
            context.SurveyTemplates.Add(surveyTemplateToCreate);
            context.SaveChangesAsync();
        }

        public IEnumerable<SurveyTemplateDataModel> GetSurveyTemplatesByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId.ToString() == creatorId);
        }
    }
}