using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<AnswerServiceModel, AnswerDataModel>();
            CreateMap<AnswerDataModel, AnswerServiceModel>();

            CreateMap<QuestionServiceModel, QuestionDataModel>();
            CreateMap<QuestionDataModel, QuestionServiceModel>();

            CreateMap<PageServiceModel, PageDataModel>();
            CreateMap<PageDataModel, PageServiceModel>();

            CreateMap<SurveyTemplateDataModel, SurveyServiceModel>();
            CreateMap<CreatedSurveyServiceModel, SurveyTemplateDataModel>();

            CreateMap<SurveyDataModel, SurveyServiceModel>(MemberList.None);
            CreateMap<CreatedSurveyServiceModel, SurveyDataModel>();
        }
    }
}