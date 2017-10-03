using AutoMapper;
using SurveyApp.BLL.Models.common;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class PageServiceToDataResolver : IValueResolver<PageServiceModel, PageDataModel, PageDataModel>
    {
        private readonly SurveyDataModel _survey;

        public PageServiceToDataResolver(SurveyDataModel survey)
        {
            _survey = survey;
        }

        public PageDataModel Resolve(PageServiceModel source, PageDataModel destination, PageDataModel destMember,
            ResolutionContext context)
        {
            var page = context.Mapper.Map<PageDataModel>(source);

            return null;
        }
    }
}