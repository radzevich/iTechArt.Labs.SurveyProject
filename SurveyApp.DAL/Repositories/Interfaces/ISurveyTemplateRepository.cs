﻿using System.Collections.Generic;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Repositories.Interfaces
{
    public interface ISurveyTemplateRepository
    {
        void SaveAsync(SurveyTemplateDataModel surveyTemplateToCreate);
        IEnumerable<SurveyTemplateDataModel> GetSurveyTemplatesByCreatorId(string creatorId);
    }
}