using System;
using System.Collections.Generic;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        void CreateAsync(SurveyDataModel surveyToCreate);
        IEnumerable<SurveyDataModel> GetSurveysByCreatorId(string creatorId);
    }
}