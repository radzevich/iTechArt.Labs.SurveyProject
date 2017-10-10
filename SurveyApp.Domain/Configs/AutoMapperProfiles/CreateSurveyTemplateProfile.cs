using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperResolvers;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    class CreateSurveyTemplateProfile : Profile 
    {
        public CreateSurveyTemplateProfile()
        {
            CreateMap<CreatedSurveyServiceModel, SurveyTemplateDataModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
                .ForMember(dest => dest.Modifier, opt => opt.Ignore())
                .ForMember(dest => dest.ModifierId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<PageListResolver>())
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<QuestionListResolver>());
        }
    }
}
