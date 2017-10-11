using System.Collections.Generic;
using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class DownAnswerListResolver : IValueResolver<QuestionServiceModel, QuestionDataModel, ICollection<AnswerDataModel>>
    {
        public ICollection<AnswerDataModel> Resolve(QuestionServiceModel source, QuestionDataModel destination, ICollection<AnswerDataModel> destMember,
            ResolutionContext context)
        {
            List<AnswerDataModel> answersToQuestion = Mapper.Map<List<AnswerDataModel>>(source.Answers);

            foreach (var answer in answersToQuestion)
            {
                answer.Question = destination;
            }

            return answersToQuestion;
        }
    }
}