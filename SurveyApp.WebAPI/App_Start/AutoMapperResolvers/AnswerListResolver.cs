using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class AnswerListResolver : IValueResolver<QuestionViewModel, QuestionServiceModel, AnswerServiceModel[]>
    {
        public AnswerServiceModel[] Resolve(QuestionViewModel source, QuestionServiceModel destination, AnswerServiceModel[] destMember,
            ResolutionContext context)
        {
            AnswerServiceModel[] answersToQuestion = Mapper.Map<AnswerServiceModel[]>(source.Answers);

            return answersToQuestion;
        }
    }
}