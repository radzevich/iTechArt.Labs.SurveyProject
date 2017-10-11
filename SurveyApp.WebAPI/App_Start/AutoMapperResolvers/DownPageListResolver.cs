using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class DownPageListResolver : IValueResolver<CreatedSurveyViewModel, DownloadSurveyServiceModel, PageServiceModel[]>
    {
        public PageServiceModel[] Resolve(CreatedSurveyViewModel source, DownloadSurveyServiceModel destination, PageServiceModel[] destMember,
            ResolutionContext context)
        {
            PageServiceModel[] surveyPages = Mapper.Map<PageServiceModel[]>(source.Pages);
            return surveyPages;
        }
    }
}