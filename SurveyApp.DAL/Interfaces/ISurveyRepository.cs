using System;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Interfaces
{
    public interface ISurveyRepository
    {
        void Create(SurveyDataModel surveyToCreate);
    }
}