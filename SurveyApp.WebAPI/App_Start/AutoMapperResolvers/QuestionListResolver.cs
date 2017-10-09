using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class QuestionListResolver : IValueResolver<PageViewModel, PageServiceModel, QuestionServiceModel[]>
    {
        public QuestionServiceModel[] Resolve(PageViewModel source, PageServiceModel destination, QuestionServiceModel[] destMember,
            ResolutionContext context)
        {
            QuestionServiceModel[] questionsOnPage = (from questionViewModel in source.Questions
                                                      select context.Mapper.Map<QuestionServiceModel>(questionViewModel))
                                                      .ToArray();

            return questionsOnPage;
        }
    }
}