using System.Collections.Generic;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class SurveyServiceModelToSurveyDataModelResolver 
        : IValueResolver<CreateSurveyServiceModel, SurveyDataModel, ICollection<QuestionDataModel>>
    {
        public ICollection<QuestionDataModel> Resolve(CreateSurveyServiceModel source, SurveyDataModel destination, ICollection<QuestionDataModel> destMember,
            ResolutionContext context)
        {
            return null;
        }
    }
}