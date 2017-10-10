using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperResolvers;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperProfiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<AnswerServiceModel, AnswerDataModel>()
                .ForMember(dest => dest.Question, opt => opt.Ignore())
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore());
            CreateMap<AnswerDataModel, AnswerServiceModel>();

            CreateMap<QuestionServiceModel, QuestionDataModel>()
                .ForMember(dest => dest.AnswerOptions, opt => opt.ResolveUsing<AnswerListResolver>())
                .ForMember(dest => dest.Survey, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyId, opt => opt.Ignore())
                .ForMember(dest => dest.Page, opt => opt.Ignore())
                .ForMember(dest => dest.PageId, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedAnswers, opt => opt.Ignore());
            CreateMap<QuestionDataModel, QuestionServiceModel>()
                .ForMember(dest => dest.Answers, opt => opt.Ignore());

            CreateMap<PageServiceModel, PageDataModel>()
                .ForMember(dest => dest.Questions, opt => opt.Ignore())
                .ForMember(dest => dest.Survey, opt => opt.Ignore())
                .ForMember(dest => dest.SurveId, opt => opt.Ignore());
            CreateMap<PageDataModel, PageServiceModel>();

            //CreateMap<SurveyTemplateDataModel, SurveyServiceModel>();
            //CreateMap<SurveyDataModel, SurveyServiceModel>(MemberList.None);

            CreateMap<CreatedSurveyServiceModel, SurveyDataModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
                .ForMember(dest => dest.Modifier, opt => opt.Ignore())
                .ForMember(dest => dest.ModifierId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedSurveys, opt => opt.Ignore())
                .ForMember(dest => dest.Pages, opt => opt.Ignore())
                .ForMember(dest => dest.Questions, opt => opt.Ignore());

            //CreateMap<CreatedSurveyServiceModel, SurveyDataModel>()
            //    .ForMember(dest => dest.)
        }
    }
}