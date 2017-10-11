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
            CreateMap<AnswerViewModel, AnswerServiceModel>();
            CreateMap<AnswerServiceModel, AnswerViewModel>();

            CreateMap<QuestionViewModel, QuestionServiceModel>()
                .ForMember(dest => dest.Answers, opt => opt.ResolveUsing<DownAnswerListResolver>());
            CreateMap<QuestionServiceModel, QuestionViewModel>()
                .ForMember(dest => dest.Answers, opt => opt.ResolveUsing<UpAnswerListResolver>());

            CreateMap<PageViewModel, PageServiceModel>()
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<DownQuestionListResolver>());
            CreateMap<PageServiceModel, PageViewModel>()
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<UpQuestionListResolver>());

            CreateMap<CreatedSurveyViewModel, DownloadSurveyServiceModel>()
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<DownPageListResolver>())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore());
            CreateMap<UploadSurveyServiceModel, SurveyViewModel>()
                .ForMember(dest => dest.Pages, opt => opt.ResolveUsing<UpPageListResolver>())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore());
        }
    }
}