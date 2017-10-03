using AutoMapper;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class AnswerServiceToDataResolver : IValueResolver<AnswerDataModel, AnswerDataModel, AnswerDataModel>
    {
        private readonly QuestionDataModel _question;

        public AnswerServiceToDataResolver(QuestionDataModel question)
        {
            _question = question;
        }

        public AnswerDataModel Resolve(AnswerDataModel source, AnswerDataModel destination, AnswerDataModel destMember,
            ResolutionContext context)
        {
            var answer = context.Mapper.Map<AnswerDataModel>(source);
            answer.Question = _question;

            return answer;
        }
    }
}