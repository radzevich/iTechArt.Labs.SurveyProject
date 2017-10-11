using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class UpAnswerListResolver : IValueResolver<QuestionServiceModel, QuestionViewModel, AnswerViewModel[]>
    {
        public AnswerViewModel[] Resolve(QuestionServiceModel source, QuestionViewModel destination, AnswerViewModel[] destMember,
            ResolutionContext context)
        {
            AnswerViewModel[] answersToQuestion = Mapper.Map<AnswerViewModel[]>(source.Answers);

            return answersToQuestion;
        }
    }
}