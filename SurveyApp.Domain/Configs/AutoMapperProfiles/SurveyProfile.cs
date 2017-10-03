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
            CreateMap<SurveyDataModel, CreateSurveyServiceModel>(MemberList.None);
            CreateMap<CreateSurveyServiceModel, SurveyDataModel>();
        }
    }
}