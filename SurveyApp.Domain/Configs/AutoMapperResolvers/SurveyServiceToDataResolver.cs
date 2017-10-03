using System;
using System.Collections.Generic;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class SurveyServiceToDataResolver : IValueResolver<CreateSurveyServiceModel, SurveyDataModel, bool>
    {
        private readonly UserProfile _creator;
        private readonly IUnitOfWork _dbContext;

        public SurveyServiceToDataResolver(UserProfile creator, IUnitOfWork dbContext)
        {
            _creator = creator;
            _dbContext = dbContext;
        }

        public bool Resolve(CreateSurveyServiceModel source, SurveyDataModel destination, bool destMember,
            ResolutionContext context)
        {
            var surveyDataModel = context.Mapper.Map<SurveyDataModel>(source);

            surveyDataModel.Creator = _creator;
            surveyDataModel.Modifier = _creator;
            surveyDataModel.CreationTime = DateTime.Now;
            surveyDataModel.ModificationTime = surveyDataModel.CreationTime;

            // surveyDataModel.Questions = Mapper.Map<QuestionServiceModel, QuestionDataModel>()
            //     .ForModel(source.Pages)
            return true;
        }
    }
}