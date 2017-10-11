using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperResolvers;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    public class SurveyCommonComponentsProfile : Profile
    {
        public SurveyCommonComponentsProfile()
        {
            CreateMap<AnswerServiceModel, AnswerDataModel>()
                .ForMember(dest => dest.Question, opt => opt.Ignore())
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore());
            CreateMap<AnswerDataModel, AnswerServiceModel>();

            CreateMap<QuestionServiceModel, QuestionDataModel>()
                .ForMember(dest => dest.AnswerOptions, opt => opt.ResolveUsing<DownAnswerListResolver>())
                .ForMember(dest => dest.Survey, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyId, opt => opt.Ignore())
                .ForMember(dest => dest.Page, opt => opt.Ignore())
                .ForMember(dest => dest.PageId, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedAnswers, opt => opt.Ignore());
            CreateMap<QuestionDataModel, QuestionServiceModel>()
                .ForMember(dest => dest.Answers, opt => opt.ResolveUsing<UpAnswerListResolver>());

            CreateMap<PageServiceModel, PageDataModel>()
                .ForMember(dest => dest.Questions, opt => opt.Ignore())
                .ForMember(dest => dest.Survey, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyId, opt => opt.Ignore());
            CreateMap<PageDataModel, PageServiceModel>()
                .ForMember(dest => dest.Questions, opt => opt.ResolveUsing<UpQuestionListResolver>());
        }
    }
}