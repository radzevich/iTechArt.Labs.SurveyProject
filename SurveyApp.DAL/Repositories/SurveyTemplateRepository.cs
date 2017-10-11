using System;
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

        public async void SaveAsync(SurveyTemplateDataModel surveyTemplateToCreate)
        {
            var alreadyCreatedSurvey = await context.SurveyTemplates.FindAsync(surveyTemplateToCreate.Id);
            if (alreadyCreatedSurvey != null)
            {
                if (alreadyCreatedSurvey.CreatorId == surveyTemplateToCreate.CreatorId)
                {
                    surveyTemplateToCreate.ModificationTime = DateTime.Now;                  
                    context.SurveyTemplates.Attach(surveyTemplateToCreate);
                }
                else
                {
                    throw new AccessViolationException();
                }
            }
            else
            {
                surveyTemplateToCreate.CreationTime = DateTime.Now;
                surveyTemplateToCreate.ModificationTime = surveyTemplateToCreate.CreationTime;

                context.SurveyTemplates.Add(surveyTemplateToCreate);
            }

            await context.SaveChangesAsync();
        }

        public IEnumerable<SurveyTemplateDataModel> GetSurveyTemplatesByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId == creatorId);
        }
    }
}