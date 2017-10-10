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
            var pages = new List<PageDataModel>();
            foreach (var sourcePage in source.Pages)
            {
                var pageDataModel = Mapper.Map<PageDataModel>(sourcePage);
                pageDataModel.Survey = destination;
                pages.Add(pageDataModel);          
            }

            return pages;
        }
    }
}