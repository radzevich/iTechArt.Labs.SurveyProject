using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class PageListResolver : IValueResolver<CreatedSurveyServiceModel, SurveyDataModel, ICollection<PageDataModel>>
    {
        public ICollection<PageDataModel> Resolve(CreatedSurveyServiceModel source, SurveyDataModel destination, ICollection<PageDataModel> destMember,
            ResolutionContext context)
        {
            ICollection<PageDataModel> surveyPages = (from pageServiceModel in source.Pages
                                               select context.Mapper.Map<PageDataModel>(pageServiceModel))
                                               .ToList();

            foreach (var page in surveyPages)
            {
                page.Survey = destination;
            }

            return surveyPages;
        }
    }
}