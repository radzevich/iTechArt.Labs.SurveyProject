using System;
using System.Collections.Generic;
using System.Security.Authentication;
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

        public async void SaveAsync(SurveyDataModel surveyToSave)
        {
            var alreadyCreatedSurvey = await context.Surveys.FindAsync(surveyToSave.Id);
            if (alreadyCreatedSurvey != null)
            {
                if (alreadyCreatedSurvey.CreatorId == surveyToSave.CreatorId)
                {
                    context.Surveys.Attach(surveyToSave);
                }
                else
                {
                    throw new AccessViolationException();
                }
            }
            else
            {
                context.Surveys.Add(surveyToSave);
            }

            await context.SaveChangesAsync();
        }

        public IEnumerable<SurveyDataModel> GetSurveysByCreatorId(string creatorId)
        {
            return Get(survey => survey.CreatorId == creatorId);
        }
    }
}