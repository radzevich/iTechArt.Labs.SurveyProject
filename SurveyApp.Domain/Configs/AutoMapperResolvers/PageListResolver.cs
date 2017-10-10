using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.BLL.Configs.AutoMapperResolvers
{
    public class PageListResolver : IValueResolver<SurveyServiceModel, SurveyBaseDataModel, ICollection<PageDataModel>>
    {
        public ICollection<PageDataModel> Resolve(SurveyServiceModel source, SurveyBaseDataModel destination, ICollection<PageDataModel> destMember,
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