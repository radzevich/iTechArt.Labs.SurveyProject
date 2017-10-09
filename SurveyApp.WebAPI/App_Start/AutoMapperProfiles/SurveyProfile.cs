using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.AutoMapperResolvers;
using SurveyApp.WebAPI.Models;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<CreatedSurveyViewModel, CreatedSurveyServiceModel>()
                //.ForMember(dest => dest.Pages, opt => opt.ResolveUsing<PageListResolver>())
                .ForMember(dest => dest.Pages, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore());
            CreateMap<PageViewModel, PageServiceModel>()
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<QuestionListResolver>());
            CreateMap<QuestionViewModel, QuestionServiceModel>()
                .ForMember(dest => dest.Answers, opt => opt.ResolveUsing<AnswerListResolver>());

           // CreateMap<CrSurveyViewModel, SurveyServiceModel>().ReverseMap();
           
            //CreateMap<SurveyServiceModel, SurveyViewModel>();
        }
    }
}