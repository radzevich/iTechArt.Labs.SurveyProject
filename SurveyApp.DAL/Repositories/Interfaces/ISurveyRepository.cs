using System;
using System.Collections.Generic;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        void SaveAsync(SurveyDataModel surveyToSave);
        IEnumerable<SurveyDataModel> GetSurveysByCreatorId(string creatorId);
    }
}