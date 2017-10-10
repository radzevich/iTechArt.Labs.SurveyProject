using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class PageListResolver : IValueResolver<CreatedSurveyViewModel, SurveyServiceModel, PageServiceModel[]>
    {
        public PageServiceModel[] Resolve(CreatedSurveyViewModel source, SurveyServiceModel destination, PageServiceModel[] destMember,
            ResolutionContext context)
        {
            PageServiceModel[] surveyPages = Mapper.Map<PageServiceModel[]>(source.Pages);
            return surveyPages;
        }
    }
}