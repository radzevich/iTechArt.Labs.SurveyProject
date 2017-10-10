using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class QuestionListResolver : IValueResolver<CreatedSurveyServiceModel, SurveyDataModel, ICollection<QuestionDataModel>>
    {
        public ICollection<QuestionDataModel> Resolve(CreatedSurveyServiceModel source, SurveyDataModel destination, ICollection<QuestionDataModel> destMember,
            ResolutionContext context)
        {
            var questions =  new List<QuestionDataModel>();
            for (var pageIndex = 0; pageIndex < source.Pages.Length; pageIndex++)
            {
                var sourcePage = source.Pages.ElementAt(pageIndex);
                var destPage = destination.Pages.ElementAt(pageIndex);
                foreach (var question in sourcePage.Questions)
                {
                    var questionDataModel = Mapper.Map<QuestionDataModel>(question);

                    questionDataModel.Survey = destination;    
                    questionDataModel.Page = destPage;

                    questions.Add(questionDataModel);
                }
            }

            return questions;
        }
    }
}