using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<SurveyDataModel, SurveyServiceModel>();
            CreateMap<SurveyServiceModel, SurveyDataModel>();
        }
    }
}