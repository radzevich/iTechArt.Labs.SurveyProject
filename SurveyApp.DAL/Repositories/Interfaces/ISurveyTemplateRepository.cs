using System.Collections.Generic;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Repositories.Interfaces
{
    public interface ISurveyTemplateRepository
    {
        void Create(SurveyTemplateDataModel surveyTemplateToCreate);
        IEnumerable<SurveyTemplateDataModel> GetSurveyTemplatesByCreatorId(string creatorId);
    }
}