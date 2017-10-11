using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class UpQuestionListResolver : IValueResolver<PageServiceModel, PageViewModel, QuestionViewModel[]>
    {
        public QuestionViewModel[] Resolve(PageServiceModel source, PageViewModel destination, QuestionViewModel[] destMember,
            ResolutionContext context)
        {
            QuestionViewModel[] questionsOnPage = Mapper.Map<QuestionViewModel[]>(source.Questions);

            return questionsOnPage;
        }
    }
}