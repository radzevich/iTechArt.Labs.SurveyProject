using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    class UpAnswerListResolver : IValueResolver<QuestionDataModel, QuestionServiceModel, AnswerServiceModel[]>
    {
        public AnswerServiceModel[] Resolve(QuestionDataModel source, QuestionServiceModel destination, AnswerServiceModel[] destMember,
            ResolutionContext context)
        {
            AnswerServiceModel[] answersToQuestion = Mapper.Map<AnswerServiceModel[]>(source.AnswerOptions);

            return answersToQuestion;
        }
    }
}
