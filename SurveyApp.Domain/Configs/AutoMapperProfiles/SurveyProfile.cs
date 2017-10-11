using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperResolvers;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<DownloadSurveyServiceModel, SurveyDataModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedSurveys, opt => opt.Ignore())
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<DownPageListResolver>())
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<DownQuestionListResolver>());

            CreateMap<DownloadSurveyServiceModel, SurveyTemplateDataModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<DownPageListResolver>())
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<DownQuestionListResolver>());

            CreateMap<SurveyDataModel, UploadSurveyServiceModel>()
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<UpPageListResolver>());
            CreateMap<SurveyTemplateDataModel, UploadSurveyServiceModel>()
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<UpPageListResolver>());
        }
    }
}