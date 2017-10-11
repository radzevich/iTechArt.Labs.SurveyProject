using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    class UpQuestionListResolver : IValueResolver<PageDataModel, PageServiceModel, QuestionServiceModel[]>
    {
        public QuestionServiceModel[] Resolve(PageDataModel source, PageServiceModel destination, QuestionServiceModel[] destMember,
            ResolutionContext context)
        {
            QuestionServiceModel[] questionsOnPage = Mapper.Map<QuestionServiceModel[]>(source.Questions);

            return questionsOnPage;
        }
    }
}
