using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class QuestionServiceToDataResolver : IValueResolver<QuestionServiceModel, QuestionDataModel, QuestionDataModel>
    {
        private readonly SurveyDataModel _survey;
        private readonly PageDataModel _page;

        public QuestionServiceToDataResolver(SurveyDataModel survey, PageDataModel page)
        {
            _survey = survey;
            _page = page;
        }

        public QuestionDataModel Resolve(QuestionServiceModel source, QuestionDataModel destination, QuestionDataModel destMember,
            ResolutionContext context)
        {
            var question = context.Mapper.Map<QuestionDataModel>(source);

            question.Survey = _survey;
            question.Page = _page;

            foreach (var answer in source.Answers)
            {
                question.AnswerOptions.Add(context.Mapper.Map<AnswerDataModel>(answer));
            }

            return question;
        }
    }
}