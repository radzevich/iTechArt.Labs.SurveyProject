using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.WebAPI.Models;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.AutoMapperResolvers
{
    public class UpPageListResolver : IValueResolver<UploadSurveyServiceModel, SurveyViewModel, PageViewModel[]>
    {
        public PageViewModel[] Resolve(UploadSurveyServiceModel source, SurveyViewModel destination, PageViewModel[] destMember,
            ResolutionContext context)
        {
            PageViewModel[] surveyPages = Mapper.Map<PageViewModel[]>(source.Pages);
            return surveyPages;
        }
    }
}